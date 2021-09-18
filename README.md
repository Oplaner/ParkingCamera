# Parking Camera

🇵🇱

Program na system Windows symulujący działanie kamery odczytującej rejestracje pojazdów na parkingu. Wykorzystuje dostępną w usłudze Microsoft Azure technologię rozpoznawania tekstu na obrazie (OCR) oraz bazę danych SQL.

🇬🇧

A Windows program simulating a camera recognizing license plates of vehicles at a parking lot. It takes advantage of Microsoft Azure text recognition technology (OCR) and an SQL database.

## Interfejs | Interface

![Interface 1](https://user-images.githubusercontent.com/23143311/133908566-23fcdc1c-3fcc-4a1a-89e9-f4ee67afcda0.png)

![Interface 2](https://user-images.githubusercontent.com/23143311/133910898-d59c315f-1490-464a-8712-3c7907d3a225.png)

## Symulacja | Simulation

_---1---_

🇵🇱

Samochód podjeżdża pod bramkę na parkingu i aktywuje czujnik, który inicjuje wykonanie zdjęcia pojazdu. Ten proces jest symulowany poprzez ręczne wybranie obrazu z widoczną tablicą rejestracyjną.

🇬🇧

A car is approaching a parking gate and activates a detector, which initializes taking a photo of the vehicle. This process is simulated by manually choosing an image with a visible license plate.

![Simulation 1](https://user-images.githubusercontent.com/23143311/133908684-db325a0d-f14b-4987-bcad-d81b38bacf52.png)

_---2---_

🇵🇱

Zdjęcie jest przesyłane do usługi OCR w Microsoft Azure. Odczytywany jest tekst na obrazie i filtrowana jest rejestracja pojazdu. Umieszcza się ją w bazie SQL wraz z informacją o czasie wjazdu na parking.

🇬🇧

The picture is sent to the OCR service in Microsoft Azure. Text on the image is recognized and the license plate of the vehicle is filtered out. Then, it is stored in the SQL database, along with the time of entry to the parking lot.

![Simulation 2](https://user-images.githubusercontent.com/23143311/133910078-b704f446-00d3-4eb9-8bc5-2bb4404f49d2.png)

_---3---_

🇵🇱

Jeśli pojazd zostanie zeskanowany ponownie (jego rejestracja znajduje się już w bazie danych), to oznacza to wyjazd z parkingu. Wpis o obecności pojazdu na parkingu jest usuwany z bazy.

🇬🇧

If the vehicle is scanned again (its license plate text exists in the database already), it means it is leaving the parking lot. A record of its presence at the parking lot is removed from the database.

![Simulation 3](https://user-images.githubusercontent.com/23143311/133910171-e261a302-a0f0-4636-829e-a13690dfcaa8.png)

## Filtrowanie odczytów OCR | Filtering OCR results

🇵🇱

W sekcji powiadomień można zobaczyć surowe oraz przefiltrowane wyniki procesu odczytywania tablicy rejestracyjnej.

🇬🇧

In the notifications section there are both raw and filtered results of the license plate recognition process.

![Filtering 1](https://user-images.githubusercontent.com/23143311/133910456-e7582ff1-057a-43c7-8543-53a1784c24c6.png)

![Filtering 2](https://user-images.githubusercontent.com/23143311/133910465-176a7543-5b63-4699-9d12-2399360b4060.png)

![Filtering 3](https://user-images.githubusercontent.com/23143311/133910469-1b2641a1-756c-4613-9858-3219fccfc47d.png)
