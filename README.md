# Kalkulator C# WinForms z obsługą walut

## Opis projektu
Jest to aplikacja kalkulatora stworzona w technologii **C#** z użyciem **WinForms** jako interfejsu użytkownika oraz **SQLite** i **Entity Framework Core** do przechowywania historii obliczeń i kursów walut.  

Aplikacja obsługuje podstawowe operacje matematyczne (+, -, *, /), zapisuje historię obliczeń w bazie danych oraz umożliwia przeliczanie kwot według kursów walut pobranych z API NBP.

## Technologie
- C# 11 / .NET 8  
- WinForms  
- SQLite (plik `Data/Database/calculator.db`)  
- Entity Framework Core  
- API NBP do pobierania kursów walut  
- xUnit do testów jednostkowych  

## Struktura katalogów
    Calculator/            <- projekt aplikacji  
    └─ Data/Database/      <- pliki bazy SQLite  
        └─ calculator.db
    Calculator.Tests/      <- projekt testowy  
    Calculator.sln         <- plik solucji  

## Uruchomienie
1. Uruchom aplikację `Calculator.exe`.  
### LUB
1. Otwórz plik `Calculator.sln` w Visual Studio 2022 lub nowszym.  
2. Upewnij się, że plik `Data/Database/calculator.db` jest w projekcie i ustawiony na:  
       Build Action: Content  
       Copy to Output Directory: Copy if newer  
3. Zbuduj projekt (`Build Solution`).  
4. Uruchom projekt (`Start Debugging` lub `Ctrl+F5`).  

## Funkcjonalności
- Kalkulator liczbowy:
       - Operacje: dodawanie, odejmowanie, mnożenie, dzielenie.  
       - Historia obliczeń zapisywana w bazie SQLite (`Operations`).  
- Przelicznik walut:  
       - Pobieranie kursów walut z API NBP w określonym zakresie dat.  
       - Wybór najlepszego dnia dla konwersji (najwyższy kurs).  
       - Wyliczanie kwoty po przewalutowaniu.  
       - Dane kursów zapisywane w bazie SQLite (`CurrencyRates`)  

## Testy jednostkowe
- Projekt testowy `Calculator.Tests` zawiera testy jednostkowe dla:  
       - Kalkulatora (`CalculatorEngine`)  
       - Przelicznika walut (`CurrencyService`)  

Aby uruchomić testy:  
1. Otwórz `Test Explorer` w Visual Studio.  
2. Wybierz `Run All` lub uruchom wybrane testy.  

## Argumentacja wyborów projektowych
- **Entity Framework Core + SQLite** – pozwala na szybkie i proste zarządzanie historią i kursami walut, bez potrzeby instalowania zewnętrznych baz danych.  
- **WinForms** – intuicyjny i przejrzysty interfejs, łatwy do rozwinięcia o dodatkowe funkcjonalności.  
- **API NBP** – zapewnia aktualne kursy walut.  
- **Struktura bazy danych** – dwie tabele: `Operations` dla historii kalkulatora i `CurrencyRates` dla kursów walut.  

## Wnioski
Projekt spełnia wymagania podstawowe kalkulatora oraz dodatkowe funkcjonalności związane z walutami.  
Kod źródłowy jest podzielony na warstwę logiki (`CalculatorEngine`), warstwę dostępu do danych (EF Core) i interfejs użytkownika (WinForms).  

## Pliki w repozytorium
- `Calculator/` – źródła aplikacji.  
- `Calculator.Tests/` – źródła testów jednostkowych.  
- `Data/Database/calculator.db` – plik bazy danych.  
- `Calculator.sln` – plik solution Visual Studio.
