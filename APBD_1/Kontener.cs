namespace APBD_1;

public abstract class Kontener
{
    private static int _licznik = 1;
    public string NumerSeryjny { get; }
    public double Waga { get; }
    public double Wysokość { get; }
    public double Głębokość { get; }
    public double MasaŁadunku { get; protected set; }
    public double MaxZaładunek { get; }
    
    protected Kontener(string typ, double maxZaładunek, double waga, double wysokość, double głębokość)
    {
        NumerSeryjny = $"KON-{typ}-{_licznik++}";
        MaxZaładunek = maxZaładunek;
        Waga = waga;
        Wysokość = wysokość;
        Głębokość = głębokość;
    }

    public abstract void Załaduj(double masa);
    public abstract void Wyładuj();

}