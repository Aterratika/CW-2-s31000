using APBD_1;

List<Kontener> wszystkieKontenery = new List<Kontener>();
List<Kontenerowiec> wszystkieKontenerowce = new List<Kontenerowiec>();
Kontenerowiec? kontenerowiec = null;

bool exit = false;

while (!exit)
{
    Console.WriteLine("\n=== MENU ===");
    Console.WriteLine("1. Dodaj kontenerowiec");
    Console.WriteLine("2. Dodaj kontener");
    Console.WriteLine("3. Opcje kontenera");
    Console.WriteLine("4. Opcje kontenerowca");
    Console.WriteLine("5. Wyjście");
    Console.Write("Wybierz opcję: ");

    string? opcja = Console.ReadLine();

    switch (opcja)
    {
        case "1":
            Console.WriteLine("Podaj dane kontenerowca: <maxPrędkość> <maxLiczbaKontenerów> <maxWaga>");
            string? daneStatku = Console.ReadLine();
            if (daneStatku != null)
            {
                var czesci1 = daneStatku.Split(' ');
                if (czesci1.Length >= 3 &&
                    double.TryParse(czesci1[0], out double predkosc) &&
                    double.TryParse(czesci1[1], out double liczbaKontenerow) &&
                    double.TryParse(czesci1[2], out double maxWaga))
                {
                    kontenerowiec = new Kontenerowiec(predkosc, liczbaKontenerow, maxWaga);
                    wszystkieKontenerowce.Add(kontenerowiec);
                    Console.WriteLine("Dodano kontenerowiec.");
                }
                else Console.WriteLine("Niepoprawne dane. Spróbuj ponownie.");
            }
            break;

        case "2":
            Console.WriteLine("Wybierz rodzaj kontenera:");
            Console.WriteLine("1. Na płyny");
            Console.WriteLine("2. Na gaz");
            Console.WriteLine("3. Chłodniczy");
            Console.WriteLine("4. Cofnij");
            string? typKontenera = Console.ReadLine();

            switch (typKontenera)
            {
                case "1":
                    Console.WriteLine("Podaj dane kontenera: <czyNiebezpieczny> <maxZaładunek> <waga> <wysokość> <głębokość>");
                    string? linia1 = Console.ReadLine();
                    if (linia1 != null)
                    {
                        string[] czesci = linia1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (czesci.Length >= 5 &&
                            bool.TryParse(czesci[0], out bool niebezpieczny) &&
                            double.TryParse(czesci[1], out double max1) &&
                            double.TryParse(czesci[2], out double waga1) &&
                            double.TryParse(czesci[3], out double wys1) &&
                            double.TryParse(czesci[4], out double gleb1))
                        {
                            var kontener = new KontenerNaPłyny(niebezpieczny, max1, waga1, wys1, gleb1);
                            wszystkieKontenery.Add(kontener);
                            Console.WriteLine($"Dodano kontener: {kontener.NumerSeryjny}");
                        }
                        else Console.WriteLine("Niepoprawne dane.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Podaj dane kontenera na gaz: <ciśnienie> <maxZaładunek> <waga> <wysokość> <głębokość>");
                    string? linia2 = Console.ReadLine();
                    if (linia2 != null)
                    {
                        string[] czesci = linia2.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (czesci.Length >= 5 &&
                            double.TryParse(czesci[0], out double cisnienie) &&
                            double.TryParse(czesci[1], out double max2) &&
                            double.TryParse(czesci[2], out double waga2) &&
                            double.TryParse(czesci[3], out double wys2) &&
                            double.TryParse(czesci[4], out double gleb2))
                        {
                            var kontener = new KontenerNaGaz(cisnienie, max2, waga2, wys2, gleb2);
                            wszystkieKontenery.Add(kontener);
                            Console.WriteLine($"Dodano kontener gazowy: {kontener.NumerSeryjny}");
                        }
                        else Console.WriteLine("Niepoprawne dane.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Podaj dane kontenera chłodniczego:");
                    Console.WriteLine("<typProduktu> <temperatura> <maxZaładunek> <waga> <wysokość> <głębokość>");
                    string? linia3 = Console.ReadLine();
                    if (linia3 != null)
                    {
                        string[] dane = linia3.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (dane.Length >= 6)
                        {
                            string typ = dane[0];
                            double.TryParse(dane[1], out double temperatura);
                            double.TryParse(dane[2], out double max3);
                            double.TryParse(dane[3], out double waga3);
                            double.TryParse(dane[4], out double wys3);
                            double.TryParse(dane[5], out double gleb3);

                            try
                            {
                                var kontener = new KontenerChłodniczy(typ, temperatura, max3, waga3, wys3, gleb3);
                                wszystkieKontenery.Add(kontener);
                                Console.WriteLine($"Dodano kontener chłodniczy: {kontener.NumerSeryjny}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Błąd: " + ex.Message);
                            }
                        }
                        else Console.WriteLine("Za mało danych.");
                    }
                    break;
            }
            break;
        case "3":
            Console.WriteLine("Opcje kontenera:");
            Console.WriteLine("1. Załadowanie ładunku");
            Console.WriteLine("2. Załadowanie kontenera na statek");
            Console.WriteLine("3. Załadowanie listy kontenerów na statek");
            Console.WriteLine("4. Usunięcie kontenera ze statku");
            Console.WriteLine("5. Rozładowanie kontenera");
            Console.WriteLine("6. Informacje o danym kontenerze");
            Console.WriteLine("7. Cofnij.");
            string opcje = Console.ReadLine();

            switch (opcje)
            {
                case "1":
                    Console.WriteLine("Wybierz ID kontenera, do którego chcesz załadować ładunek:");
                    Console.WriteLine("Lista kontenerów:");
                    foreach (var k in wszystkieKontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }

                    string? ID = Console.ReadLine();
                    Kontener znaleziony = wszystkieKontenery.Find(k => k.NumerSeryjny == ID);
                    if (znaleziony != null)
                    {
                        Console.WriteLine("Podaj masę załadowywanego ładunku");
                        string? masa = Console.ReadLine();
                        double.TryParse(masa, out double masa1);
                        if (masa1 < znaleziony.MaxZaładunek)
                        {
                            znaleziony.Załaduj(masa1);
                            Console.WriteLine("Kontener załadowany pomyślnie!");
                        } else Console.WriteLine("Zbyt duża masa ładunku.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono kontenera.");
                    }


                    break;
                case "2":
                    Console.WriteLine("Wybierz ID kontenera, który chcesz załadować na statek:");
                    Console.WriteLine("Lista kontenerów:");
                    foreach (var k in wszystkieKontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }

                    string? ID1 = Console.ReadLine();
                    Kontener znaleziony1 = wszystkieKontenery.Find(k => k.NumerSeryjny == ID1);
                    if (znaleziony1 != null)
                    {
                        Console.WriteLine("Wybierz ID kontenerowca na który chcesz załadować kontener:");
                        Console.WriteLine("Lista kontenerowców:");
                        foreach (var k in wszystkieKontenerowce)
                        {
                            Console.WriteLine($"- {k.ID} ({k.GetType().Name})");
                        }

                        string? ID2 = Console.ReadLine();
                        Kontenerowiec znaleziony2 = wszystkieKontenerowce.Find(k => k.ID == ID2);
                        znaleziony2.Ładowanie(znaleziony1);
                        Console.WriteLine("Kontener został załadowany na statek pomyślnie.");
                    }
                    else Console.WriteLine("Nie znaleziono kontenera");

                    break;
                case "3":
                    Console.WriteLine("Wpisuj numery seryjne kontenerów, które chcesz załadować (napisz 'stop', aby zakończyć):");
                    Console.WriteLine("Lista wszystkich kontenerów:");
                    foreach (var k in wszystkieKontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }

                    List<Kontener> doŁadowania = new List<Kontener>();

                    while (true)
                    {
                        Console.Write("ID kontenera: ");
                        string? wpis = Console.ReadLine();

                        if (wpis?.ToLower() == "stop") break;

                        var znaleziony3 = wszystkieKontenery.Find(k => k.NumerSeryjny == wpis);
                        if (znaleziony3 != null)
                        {
                            doŁadowania.Add(znaleziony3);
                            Console.WriteLine($"Dodano kontener {znaleziony3.NumerSeryjny} do listy.");
                        }
                        else Console.WriteLine("Nie znaleziono kontenera.");
                    }

                    if (doŁadowania.Count == 0)
                    {
                        Console.WriteLine("Nie wybrano żadnych kontenerów do załadunku.");
                        break;
                    }

                    Console.WriteLine("Wybierz ID kontenerowca:");
                    foreach (var statek in wszystkieKontenerowce)
                    {
                        Console.WriteLine($"- {statek.ID}");
                    }
                    
                    string? ID5 = Console.ReadLine();
                    var znaleziony5 = wszystkieKontenerowce.Find(s => s.ID == ID5);

                    if (znaleziony5 != null)
                    {
                        znaleziony5.ŁadowanieListy(doŁadowania);
                    }
                    else Console.WriteLine("Nie znaleziono kontenerowca.");
                    break;
                
                case "4":
                    Console.WriteLine("Wybierz ID statku, z którego chcesz usunąć kontener:");
                    Console.WriteLine("Lista kontenerowców:");
                    foreach (var k in wszystkieKontenerowce)
                    {
                        Console.WriteLine($"- {k.ID} ({k.GetType().Name})");
                    }
                    string ID6= Console.ReadLine();
                    Kontenerowiec znaleziony6 = wszystkieKontenerowce.Find(k => k.ID == ID6);
                    Console.WriteLine("Wybierz ID kontenera, który chcesz usunąć:");
                    Console.WriteLine("Kontenery na statku:");
                    foreach (var k in znaleziony6._kontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }
                    string? ID7 = Console.ReadLine();
                    Kontener znaleziony7 = znaleziony6._kontenery.Find(k => k.NumerSeryjny == ID7);
                    if (znaleziony7 != null)
                    {
                        znaleziony6._kontenery.Remove(znaleziony7);
                    }
                    else Console.WriteLine("Nie znaleziono kontenera");

                    break;
                case "5":
                    Console.WriteLine("Wybierz ID kontenera, który chcesz rozładować");
                    Console.WriteLine("Lista kontenerów:");
                    foreach (var k in wszystkieKontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }

                    string? ID8 = Console.ReadLine();
                    Kontener znaleziony8 = wszystkieKontenery.Find(k => k.NumerSeryjny == ID8);
                    if (znaleziony8 != null)
                    {
                        znaleziony8.Wyładuj();
                    } else Console.WriteLine("Nie znaleziono kontenera");

                    break;
                case "6":
                    Console.WriteLine("Wybierz kontener, którego informacje chcesz wyświetlić:");
                    Console.WriteLine("Lista kontenerów:");
                    foreach (var k in wszystkieKontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name})");
                    }
                    string? ID9 = Console.ReadLine();
                    Kontener znaleziony9 = wszystkieKontenery.Find(k => k.NumerSeryjny == ID9);
                    if (znaleziony9 != null)
                    {
                        Console.WriteLine($"{znaleziony9.NumerSeryjny} ({znaleziony9.GetType().Name})" +
                                          $" | Masa: {znaleziony9.MasaŁadunku} kg / {znaleziony9.MaxZaładunek} kg");
                        Console.WriteLine($"Wymiary: Wysokość: {znaleziony9.Wysokość} Głębokość: {znaleziony9.Głębokość}");
                        Console.WriteLine($"Masa bez ładunku: {znaleziony9.Waga}");
                    }

                    break;
            }

            break;
        case "4":
            Console.WriteLine("Opcje kontenerowca:");
            Console.WriteLine("1. Zastąp kontener na statku innym kontenerem.");
            Console.WriteLine("2. Przenieś kontener między statkami.");
            Console.WriteLine("3. Wyświetl informacje o statku i jego ładunku.");
            Console.WriteLine("4. Cofnij.");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.WriteLine("Wybierz ID statku, na którym chcesz podmienić kontenery:");
                    Console.WriteLine("Lista kontenerowców:");
                    foreach (var k in wszystkieKontenerowce)
                    {
                        Console.WriteLine($"- {k.ID} ({k.GetType().Name})");
                    }
                    string ID10 = Console.ReadLine();
                    Kontenerowiec znaleziony10 = wszystkieKontenerowce.Find(k => k.ID == ID10);
                    Console.WriteLine("Wybierz ID kontenera, który chcesz zamienić.");
                    Console.WriteLine($"Lista kontenerów na statku:");
                    foreach (var k in znaleziony10._kontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }
                    string? ID11 = Console.ReadLine();
                    Kontener znaleziony11 = znaleziony10._kontenery.Find(k => k.NumerSeryjny == ID11);
                    Console.WriteLine("Wybierz kontener, który ma znależć się na statku.");
                    Console.WriteLine($"Lista wszystkich kontenerów:");
                    foreach (var k in wszystkieKontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }
                    string? ID12 = Console.ReadLine();
                    Kontener znaleziony12 = wszystkieKontenery.Find(k => k.NumerSeryjny == ID12);
                    if (znaleziony12 != null && znaleziony11 != null)
                    {
                        znaleziony10._kontenery.Remove(znaleziony11);
                        znaleziony10._kontenery.Add(znaleziony12);
                        Console.WriteLine("Kontenery zamienione pomyślnie.");
                    } else Console.WriteLine("Nie znaleziono kontenerów.");

                    break;
                
                case "2":
                    Console.WriteLine("Wybierz ID statku, z którego przeniesiesz kontener oraz statek, na który kontener zostanie przeniesiony:");
                    Console.WriteLine("Lista kontenerowców:");
                    foreach (var k in wszystkieKontenerowce)
                    {
                        Console.WriteLine($"- {k.ID} ({k.GetType().Name})");
                    }
                    Console.Write("Pierwszy statek:");
                    string ID13 = Console.ReadLine();
                    Kontenerowiec znaleziony13 = wszystkieKontenerowce.Find(k => k.ID == ID13); //1 statek
                    
                    Console.Write("Drugi statek:");
                    string? ID14 = Console.ReadLine();
                    Kontenerowiec znaleziony14 = wszystkieKontenerowce.Find(k => k.ID == ID14); //2 statek
                    Console.WriteLine("Wybierz kontener, który chcesz przenieść.");
                    Console.WriteLine($"Lista kontenerów możliwych do przeniesienia:");
                    foreach (var k in znaleziony13._kontenery)
                    {
                        Console.WriteLine(
                            $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
                    }
                    string? ID15 = Console.ReadLine();
                    Kontener znaleziony15 = wszystkieKontenery.Find(k => k.NumerSeryjny == ID15);
                    if (znaleziony13 != null && znaleziony14 != null && znaleziony15 != null)
                    {
                        znaleziony13._kontenery.Remove(znaleziony15);
                        znaleziony14._kontenery.Add(znaleziony15);
                        Console.WriteLine("Kontener przeniesiony pomyślnie.");
                        
                    } else Console.WriteLine("Nie znaleziono kontenerowców, ani kontenera.");
                    break;
                case "3":
                    Console.WriteLine("Wybierz ID kontenerowca, o którym chcesz wyświtlić informaje:");
                    Console.WriteLine("Lista kontenerowców:");
                    foreach (var k in wszystkieKontenerowce)
                    {
                        Console.WriteLine($"- {k.ID} ({k.GetType().Name})");
                    }
                    string ID16= Console.ReadLine();
                    Kontenerowiec znaleziony16 = wszystkieKontenerowce.Find(k => k.ID == ID16);
                    if (znaleziony16 != null)
                    {
                        znaleziony16.WyswietlListe();
                        Console.WriteLine(
                            $"Parametry statku: Maksymalna prędkość: {znaleziony16.MaxPrędkość} | Maksymalna liczba kontenerów: {znaleziony16.MaxLiczbaKontenerów} | " +
                            $"Maksymalna waga: {znaleziony16.MaxWaga}");
                    }
                    break;
            }
            break;

        case "5":
            exit = true;
            Console.WriteLine("Zamykam program...");
            break;

        default:
            Console.WriteLine("Nieznana opcja, spróbuj ponownie.");
            break;
    }
}
