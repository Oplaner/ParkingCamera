using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingCamera
{
    public partial class ParkingCamera : Form
    {
        // Input image file requirements.
        private static string[] validFileExtensions = { ".bmp", ".jpg", ".png" };
        private static int maximumFileSizeInMegabytes = 6;
        private static int minimumWidth = 50;
        private static int minimumHeight = 50;
        private static int maximumWidth = 10000;
        private static int maximumHeight = 10000;

        // Azure Computer Vision: credentials and a client.
        private static string subscriptionKey = "";
        private static string endpoint = "";
        ComputerVisionClient CVClient;

        // Azure SQL database connection.
        private static string connectionString = "";

        public ParkingCamera()
        {
            InitializeComponent();

            CVClient = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey)) { Endpoint = endpoint };
            updateParkingState();
            console.Text = "Aplikacja gotowa.";
        }

        // Read text from the image using Azure Computer Vision OCR.
        private async Task ReadTextFromImage(string path)
        {
            // Send an OCR request.
            console.AppendText("\nPrzesyłanie żądania odczytu...");
            ReadInStreamHeaders requestHeaders = await CVClient.ReadInStreamAsync(new FileStream(path, FileMode.Open));

            // When the request is finished, retrieve its operation ID.
            // The operation location has the following format:
            // https://<resource name>.cognitiveservices.azure.com/vision/v<version number>/read/analyzeResults/<36-character operation ID>.
            console.AppendText("\nŻądanie ukończone.");
            string operationID = requestHeaders.OperationLocation[^36..];

            // Download results.
            console.AppendText("\nPobieranie odczytanego tekstu...");
            ReadOperationResult results;
            do results = await CVClient.GetReadResultAsync(Guid.Parse(operationID));
            while (results.Status == OperationStatusCodes.NotStarted || results.Status == OperationStatusCodes.Running);
            console.AppendText("\nPobieranie ukończone.");

            // Extract the results as a list of lines.
            List<Line> lines = new List<Line>();
            if (results.Status == OperationStatusCodes.Succeeded)
            {
                IList<ReadResult> pages = results.AnalyzeResult.ReadResults;
                if (pages.Count > 0) lines = pages[0].Lines.ToList();
            }

            // Display raw results.
            console.AppendText("\nSurowe wyniki odczytu:");
            foreach (Line line in lines) console.AppendText($"\n{line.Text}");
            console.AppendText("\n---KONIEC---");

            // Filter the results.
            filterLicensePlates(lines);

            // Display filtered results.
            console.AppendText("\nPrzefiltrowane wyniki odczytu:");
            foreach (Line line in lines) console.AppendText($"\n{line.Text}");
            console.AppendText("\n---KONIEC---");

            // If the filtered results list is not empty, choose the line which location in the image was the lowest and pass the result to the database handler.
            string result;
            if (lines.Count > 0) result = lines.Last().Text;
            else result = "--------";
            licensePlateLabel.Text = result;
            console.AppendText($"\nOdczyt: {result}");

            if (lines.Count > 0) handleVehicle(result);
        }

        // Filter out license plates from all detected lines.
        // Polish license plate texts follow some rules:
        // -consist of letters A-Z except Q, and digits 0-9,
        // -must start with a letter,
        // -must contain at least 1 digit,
        // -are between 4 and 8 characters long.
        // These are only the basic rules. This implementation does not go into the details.
        private void filterLicensePlates(List<Line> lines)
        {
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                string text = lines[i].Text.Trim().Replace(" ", "");
                if (Regex.IsMatch(text, "^[A-PR-Z][A-PR-Z0-9]{3,7}$") && Regex.IsMatch(text, "[0-9]+")) lines[i].Text = text;
                else lines.RemoveAt(i);
            }
        }

        // Add/remove vehicle to/from the parking database.
        private void handleVehicle(string licensePlateText)
        {
            // Check if a vehicle is present in the parking database.
            // Unless it is, add it. Otherwise, remove it.
            int entryID = findVehicle(licensePlateText);
            if (entryID == 0)
            {
                console.AppendText("\nPojazd wjeżdża na parking.");
                addVehicle(licensePlateText);
            }
            else
            {
                console.AppendText("\nPojazd opuszcza parking.");
                removeVehicle(entryID);
            }

            updateParkingState();
        }

        // Update the table with parked vehicles.
        private void updateParkingState()
        {
            parkingDatabaseGridView.Rows.Clear();

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM vehicleEntries ORDER BY time ASC", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                parkingDatabaseGridView.Rows.Add(new string[] { dataReader.GetInt32(0).ToString(), dataReader.GetString(1), dataReader.GetDateTime(2).ToString() });
            }

            dataReader.Close();
            command.Dispose();
            connection.Close();
        }

        private void addVehicle(string licensePlateText)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO vehicleEntries (licensePlateText, time) VALUES('{licensePlateText}', CURRENT_TIMESTAMP)", connection);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        // Return an entry ID for a vehicle with given license plate text or 0, if it doesn't exist in the parking database.
        private int findVehicle(string licensePlateText)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand($"SELECT entryID FROM vehicleEntries WHERE licensePlateText = '{licensePlateText}'", connection);
            object entryID = command.ExecuteScalar();

            command.Dispose();
            connection.Close();

            if (entryID is null) return 0;
            return (int)entryID;
        }

        private void removeVehicle(int entryID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand($"DELETE FROM vehicleEntries WHERE entryID = {entryID}", connection);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = $"Obrazy ({string.Join(", ", validFileExtensions).Replace(".", "*.")})|{string.Join(';', validFileExtensions).Replace(".", "*.")}",
                Title = "Wybierz obraz"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK) filePathTextBox.Text = fileDialog.FileName;
        }

        // Check given file path, its size and dimensions. Open and show the image. Begin reading text from it.
        private void readLicensePlateButton_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;

            if (!File.Exists(filePath) || !validFileExtensions.Contains(filePath[^4..]))
            {
                console.AppendText($"\nPodany plik nie istnieje lub ma nieodpowiednie rozszerzenie (dozwolone: {string.Join(", ", validFileExtensions)}).");
            }
            else if (new FileInfo(filePath).Length >= 1024 * 1024 * maximumFileSizeInMegabytes)
            {
                console.AppendText($"\nPodany plik ma nieodpowiedni rozmiar (nie może być większy niż {maximumFileSizeInMegabytes} MB).");
            }
            else
            {
                Bitmap image = new Bitmap(filePath);

                if (image.Width < minimumWidth || image.Height < minimumHeight || image.Width > maximumWidth || image.Height > maximumHeight)
                {
                    console.AppendText($"\nPodany obraz ma nieodpowiednie wymiary (zakres wymiarów w pikselach: od {minimumWidth} x {minimumHeight} do {maximumWidth} x {maximumHeight}).");
                    image.Dispose();
                }
                else
                {
                    // Clear previous result.
                    licensePlateLabel.Text = "--------";

                    // Using another bitmap prevents the file from being locked later on.
                    cameraPreview.Image = new Bitmap(image);
                    image.Dispose();
                    _ = ReadTextFromImage(filePath);
                }
            }
        }

        // Always scroll down to the bottom of the console.
        private void console_TextChanged(object sender, EventArgs e)
        {
            console.SelectionStart = console.Text.Length;
            console.ScrollToCaret();
        }
    }
}