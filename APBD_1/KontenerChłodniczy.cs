namespace APBD_1;

public class KontenerChłodniczy : Kontener
{
    public string TypProduktu { get; }
    public double Temperatura { get; }

    private Dictionary<string, double> ProduktyTemperatury = new Dictionary<string, double>()
    {};

    public KontenerChłodniczy(string typProduktu, double temperatura, double maxZaładunek, double waga, double wysokość, double głębokość)
        : base("C", maxZaładunek, waga, wysokość, głębokość)
    {
        TypProduktu = typProduktu;
        Temperatura = temperatura;

        if (ProduktyTemperatury.ContainsKey(TypProduktu) &&
            Temperatura < ProduktyTemperatury[TypProduktu])
        {
            throw new Exception($"Temperatura {Temperatura}°C jest za niska dla produktu '{TypProduktu}' (wymagana: {ProduktyTemperatury[TypProduktu]}°C)");
        } else DodajProduktTemperatura(typProduktu, temperatura);
    }

    public override void Załaduj(double masa)
    {
        if (masa > MaxZaładunek)
        {
            throw new OverfillException($"Przeładowano kontener chłodniczy!");
        }

        MasaŁadunku = masa;
    }

    public override void Wyładuj()
    {
        MasaŁadunku = 0;
    }
    
    public void DodajProduktTemperatura(string produkt, double temperatura)
    {
        ProduktyTemperatury[produkt] = temperatura;
    }
}