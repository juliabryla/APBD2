namespace wagony;

public class C : Kontener
{
    private string typProduktu;
    private bool maProdukt;

    public string TypProduktu 
    {
        get { return typProduktu; }
        private set { typProduktu = value; }
    }

    public double WymaganaTemperatura { get; private set; }
    public double AktualnaTemperatura { get; private set; }

    public C(double masa, double wysokosc, double wagaKontenera, double glebokosc, string numerSeryjny, double ladownoscMax, string typProduktu, double wymaganaTemperatura)
        : base(masa, wysokosc, wagaKontenera, glebokosc, numerSeryjny, ladownoscMax)
    {
        TypProduktu = typProduktu;
        WymaganaTemperatura = wymaganaTemperatura;
        AktualnaTemperatura = wymaganaTemperatura; 
        maProdukt = false;
    }

    public void UstawTemperaturę(double temperatura)
    {
        if (temperatura < WymaganaTemperatura)
        {
            throw new InvalidOperationException($"Temperatura kontenera nie może być niższa niż temperatura wymagana dla produktu typu '{TypProduktu}'.");
        }

        AktualnaTemperatura = temperatura;
    }

    public void ZaładujProdukt(string typProduktu)
    {
        if (maProdukt && this.typProduktu != typProduktu)
        {
            throw new InvalidOperationException($"Kontener już przechowuje produkt typu '{this.typProduktu}'. Nie można dodać produktu typu '{typProduktu}'.");
        }

        maProdukt = true;
        this.typProduktu = typProduktu;
    }

    public void RozładujProdukt()
    {
        maProdukt = false;
        typProduktu = null;
    }
}
