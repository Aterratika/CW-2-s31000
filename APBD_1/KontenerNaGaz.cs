namespace APBD_1;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public double Ciśnienie { get; }

    public KontenerNaGaz(double ciśnienie, double maxZaładunek, double waga, double wysokość, double głębokość)
        : base("G", maxZaładunek, waga, wysokość, głębokość)
    {
        Ciśnienie = ciśnienie;
    }

    public override void Załaduj(double masa)
    {
        if (masa > MaxZaładunek)
        {
            NotifyHazard("Przeładowano kontener na gaz!", NumerSeryjny);
            throw new OverfillException("Przeładowano kontener na gaz!");
        }

        MasaŁadunku = masa;
    }

    public override void Wyładuj()
    {
        MasaŁadunku *= 0.05;
    }

    public void NotifyHazard(string wiadomość, string numerKontenera)
    {
        Console.WriteLine($"[ALERT] {wiadomość} - kontener {numerKontenera}");
    }
}