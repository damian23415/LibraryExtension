# LibraryExtension

Stack techniczny wykorzystany w projekcie: 
- MSSQL,  
- .NET 6
- EntityFramework
- Język C#

Aby uruchomić aplikację:
1. Należy pobrać repozytorium, uruchomić i z poziomu Package Manager Console upewnić się, że startowy projekt to LibraryExtension.Infrastructure
2. Wykonać polecenie Update-Database - polecenie stworzy bazę danych oraz wypełni ją przykładowymi danymi.

Jeśli wszystko się powiodło w tym momencie mamy utworzoną bazę danych, jeśli coś się nie powiodło zwróć uwagę na swoją lokalizację pliku appsettings.json oraz w nim zawarty connectionString, czy odpowiada twojej bazie danych.

### Co dalej?
1. Aby przetestować możliwości aplikacji najprościej jest utworzyć nową solucję a w niej nowy projekt aplikacji webowej, w którym dodajemy referencję do projektów classLibrary utworzonych w tej aplikacji.
2. Kolejna rzecz to zdefiniowanie konfiguracji startowej w pliku Program.cs (utworzenie connectionString w appsettings.json analogicznego jak w przypadku implementowany projektów classLibrary oraz dodanie contextu w Program.cs)
3. Aplikacja ma domyślnie zaimportowane narzędzie swagger co ułatwia testowanie projektu
4. W Controlerze tworzymy endpointy, które chcemy przetestować i uruchamiamy aplikację, w tym momencie powinno otworzyć nam się okno przeglądarki wraz z metodą do przetestowania.
5. Używamy metody w określony sposób (zależnie od metody) i weryfikujemy czy dane pobrane czy dodane do bazy zgadzają się z tymi w bazie :)
4. Uruchomić plik Index.html, który znajduje się w: `TreeFolderStructure -> Views`.
