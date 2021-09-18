
namespace ParkingCamera
{
    partial class ParkingCamera
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.console = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.cameraPreview = new System.Windows.Forms.PictureBox();
            this.readLicensePlateButton = new System.Windows.Forms.Button();
            this.notificationsLabel = new System.Windows.Forms.Label();
            this.parkingDatabaseGridView = new System.Windows.Forms.DataGridView();
            this.parkingStateLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.licensePlateLabel = new System.Windows.Forms.Label();
            this.entryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.licensePlateText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDatabaseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.SystemColors.Window;
            this.console.Location = new System.Drawing.Point(380, 357);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.console.Size = new System.Drawing.Size(408, 81);
            this.console.TabIndex = 0;
            this.console.Text = "";
            this.console.TextChanged += new System.EventHandler(this.console_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Obraz z kamery:";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(13, 32);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.PlaceholderText = "Ścieżka do pliku";
            this.filePathTextBox.Size = new System.Drawing.Size(262, 23);
            this.filePathTextBox.TabIndex = 2;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(281, 32);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(96, 23);
            this.chooseFileButton.TabIndex = 3;
            this.chooseFileButton.Text = "Wybierz plik";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // cameraPreview
            // 
            this.cameraPreview.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cameraPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cameraPreview.Location = new System.Drawing.Point(13, 62);
            this.cameraPreview.Name = "cameraPreview";
            this.cameraPreview.Size = new System.Drawing.Size(360, 288);
            this.cameraPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cameraPreview.TabIndex = 4;
            this.cameraPreview.TabStop = false;
            // 
            // readLicensePlateButton
            // 
            this.readLicensePlateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.readLicensePlateButton.Location = new System.Drawing.Point(13, 357);
            this.readLicensePlateButton.Name = "readLicensePlateButton";
            this.readLicensePlateButton.Size = new System.Drawing.Size(360, 81);
            this.readLicensePlateButton.TabIndex = 5;
            this.readLicensePlateButton.Text = "Odczytaj rejestrację pojazdu";
            this.readLicensePlateButton.UseVisualStyleBackColor = true;
            this.readLicensePlateButton.Click += new System.EventHandler(this.readLicensePlateButton_Click);
            // 
            // notificationsLabel
            // 
            this.notificationsLabel.AutoSize = true;
            this.notificationsLabel.Location = new System.Drawing.Point(380, 334);
            this.notificationsLabel.Name = "notificationsLabel";
            this.notificationsLabel.Size = new System.Drawing.Size(92, 15);
            this.notificationsLabel.TabIndex = 6;
            this.notificationsLabel.Text = "Powiadomienia:";
            // 
            // parkingDatabaseGridView
            // 
            this.parkingDatabaseGridView.AllowUserToAddRows = false;
            this.parkingDatabaseGridView.AllowUserToDeleteRows = false;
            this.parkingDatabaseGridView.AllowUserToResizeColumns = false;
            this.parkingDatabaseGridView.AllowUserToResizeRows = false;
            this.parkingDatabaseGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.parkingDatabaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parkingDatabaseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entryID,
            this.licensePlateText,
            this.time});
            this.parkingDatabaseGridView.Location = new System.Drawing.Point(380, 122);
            this.parkingDatabaseGridView.Name = "parkingDatabaseGridView";
            this.parkingDatabaseGridView.ReadOnly = true;
            this.parkingDatabaseGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.parkingDatabaseGridView.RowTemplate.Height = 25;
            this.parkingDatabaseGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.parkingDatabaseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.parkingDatabaseGridView.ShowEditingIcon = false;
            this.parkingDatabaseGridView.Size = new System.Drawing.Size(408, 209);
            this.parkingDatabaseGridView.TabIndex = 7;
            // 
            // parkingStateLabel
            // 
            this.parkingStateLabel.AutoSize = true;
            this.parkingStateLabel.Location = new System.Drawing.Point(380, 104);
            this.parkingStateLabel.Name = "parkingStateLabel";
            this.parkingStateLabel.Size = new System.Drawing.Size(83, 15);
            this.parkingStateLabel.TabIndex = 8;
            this.parkingStateLabel.Text = "Stan parkingu:";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(380, 13);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(47, 15);
            this.resultLabel.TabIndex = 9;
            this.resultLabel.Text = "Odczyt:";
            // 
            // licensePlateLabel
            // 
            this.licensePlateLabel.AutoSize = true;
            this.licensePlateLabel.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.licensePlateLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.licensePlateLabel.Location = new System.Drawing.Point(380, 32);
            this.licensePlateLabel.Name = "licensePlateLabel";
            this.licensePlateLabel.Size = new System.Drawing.Size(206, 72);
            this.licensePlateLabel.TabIndex = 10;
            this.licensePlateLabel.Text = "--------";
            // 
            // entryID
            // 
            this.entryID.Frozen = true;
            this.entryID.HeaderText = "ID";
            this.entryID.Name = "entryID";
            this.entryID.ReadOnly = true;
            this.entryID.Width = 50;
            // 
            // licensePlateText
            // 
            this.licensePlateText.Frozen = true;
            this.licensePlateText.HeaderText = "Rejestracja";
            this.licensePlateText.Name = "licensePlateText";
            this.licensePlateText.ReadOnly = true;
            this.licensePlateText.Width = 150;
            // 
            // time
            // 
            this.time.Frozen = true;
            this.time.HeaderText = "Czas wjazdu";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 200;
            // 
            // ParkingCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.licensePlateLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.parkingStateLabel);
            this.Controls.Add(this.parkingDatabaseGridView);
            this.Controls.Add(this.notificationsLabel);
            this.Controls.Add(this.readLicensePlateButton);
            this.Controls.Add(this.cameraPreview);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ParkingCamera";
            this.Text = "Parking Camera";
            ((System.ComponentModel.ISupportInitialize)(this.cameraPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDatabaseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.PictureBox cameraPreview;
        private System.Windows.Forms.Button readLicensePlateButton;
        private System.Windows.Forms.Label notificationsLabel;
        private System.Windows.Forms.DataGridView parkingDatabaseGridView;
        private System.Windows.Forms.Label parkingStateLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label licensePlateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn licensePlateText;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
    }
}

