namespace wagony;

public class G:Kontener, IHazardNotifier
{
    private double Cisnienie;

    public G(double masa, double wysokosc, double wagaKontenera, double glebokosc, string numerSeryjny, double ladownoscMax, double cisnienie) : base(masa, wysokosc, wagaKontenera, glebokosc, numerSeryjny, ladownoscMax)
    {
        Cisnienie = cisnienie;
    }

    public override void EmptyZaladunek()
    {
        {
            base.EmptyZaladunek();
            Masa *= 0.05; 
            SendHazardNotification( "Kontener na gaz został opróżniony. Pozostało 5% ładunku wewnątrz.");
        }
    }

    public void SendHazardNotification(string message)
    {
      
    }

    public override void Zaladuj(double weight)
    {
        if (weight > LadownoscMax)
        {
            SendHazardNotification("Próba załadowania kontenera przekraczająca maksymalną ładowność");
        }

        base.Zaladuj(weight);
    }
}