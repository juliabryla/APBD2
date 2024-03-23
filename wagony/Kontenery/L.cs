namespace wagony;

public class L : Kontener,IHazardNotifier

{
    private bool isSafe;
    public L(double masa, double wysokosc, double wagaKontenera, double glebokosc, string numerSeryjny, double ladownoscMax, bool isSafe) : base(masa, wysokosc, wagaKontenera, glebokosc, numerSeryjny, ladownoscMax)
    {
        this.isSafe = isSafe;
    }

    public void SendHazardNotification(string message)
    {
        
    }

    public override void Zaladuj(double weight)
    {
       
        if (!isSafe)
        {
            double maxSafeLoad = LadownoscMax* 0.5;
            
            if (weight > maxSafeLoad)
            {
                SendHazardNotification("Próba załadowania kontenera przekraczająca 50% maksymalnej ładowności dla niebezpiecznego ładunku.");
                return;
            }
        }
        else
        {
            double maxLoad = LadownoscMax * (isSafe ? 0.9 : 0.5);
            if (weight > maxLoad)
            {
                SendHazardNotification("Próba załadowania kontenera przekraczająca maksymalną ładowność.");
                return;
            }
        }

        
        base.Zaladuj(weight);
    }
}
