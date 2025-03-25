namespace APBD_1;

public class Kontenerowiec
{
    public List<Kontener> _kontenery;
    private static int _licznik = 1;
    public double MaxPrędkość { get; }
    public double MaxLiczbaKontenerów { get; }
    public double MaxWaga { get; }
    public string ID { get; }

    public Kontenerowiec(double maxPrędkość, double maxLiczbaKontenerów, double maxWaga)
    {
        MaxPrędkość = maxPrędkość;
        MaxLiczbaKontenerów = maxLiczbaKontenerów;
        MaxWaga = maxWaga;
        ID = $"K-{_licznik++}";
        _kontenery = new List<Kontener>();
    }

    public void WyswietlListe()
    {
        if (_kontenery.Count > 0)
        {
            Console.WriteLine("Zawartość Kontenerowca (numery seryjne kontenerów):");
            foreach (var k in _kontenery)
            {
                Console.WriteLine(
                    $"- {k.NumerSeryjny} ({k.GetType().Name}) | Masa: {k.MasaŁadunku} kg / {k.MaxZaładunek} kg");
            }
        } else Console.WriteLine("Brak kontenerów na statku");
        
    }

    public void Ładowanie(Kontener kontener)
    {
        if (_kontenery.Count >= MaxLiczbaKontenerów)
        {
            Console.WriteLine("Nie można załadować – przekroczono limit liczby kontenerów.");
            return;
        }

        double aktualnaWaga = _kontenery.Sum(k => k.MasaŁadunku + k.Waga);
        double kontenerWaga = kontener.MasaŁadunku + kontener.Waga;

        if (aktualnaWaga + kontenerWaga > MaxWaga)
        {
            Console.WriteLine("Nie można załadować – przekroczono maksymalną wagę statku.");
            return;
        }

        _kontenery.Add(kontener);
        Console.WriteLine($"Kontener {kontener.NumerSeryjny} został załadowany na statek {ID}.");
    }
    public void ŁadowanieListy(List<Kontener> kontenery)
    {
        Console.WriteLine($"Ładowanie listy {kontenery.Count} kontenerów.");
        foreach (var kontener in kontenery)
        {
            Console.WriteLine($"Próba załadunku kontenera {kontener.NumerSeryjny}...");
            Ładowanie(kontener); 
        }

        Console.WriteLine("Zakończono ładowanie listy kontenerów.");
    }
}