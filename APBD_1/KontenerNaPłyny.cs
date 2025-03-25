namespace APBD_1;

public class KontenerNaPłyny : Kontener, IHazardNotifier
{
    public bool CzyNiebezpieczny { get;}
    
    public KontenerNaPłyny(bool czyNiebezpieczny, double maxZaładunek, double waga, double wysokość, double głębokość) 
        : base("L", maxZaładunek, waga, wysokość, głębokość)
    {
        CzyNiebezpieczny = czyNiebezpieczny;
    }
    
    public override void Załaduj(double masa)
    {
        double Pojemność = (CzyNiebezpieczny ? 0.5 : 0.9);
        if (masa > MaxZaładunek * Pojemność)
        {
            NotifyHazard("Kontener został przeładowany!", NumerSeryjny);
            throw new OverfillException("Przeładowano kontener na płyny!");
        }
        MasaŁadunku = masa;
    }

    public override void Wyładuj()
    {
        MasaŁadunku = 0;
    }

    public void NotifyHazard(string wiadomość, string NumerKontenera)
    {
        Console.WriteLine($"[ALERT] {wiadomość} - kontener {NumerKontenera}");
    }
}