namespace wagony;

public class Kontener
{
    public double Masa { get; set; }
    public double Wysokosc { get; set; }
    public double WagaKontenera{ get; set; }
    public double Glebokosc{ get; set; }
    public string NumerSeryjny{ get; set; }
   public double LadownoscMax{ get; set; }

    public Kontener(double masa, double wysokosc, double wagaKontenera, double glebokosc, string numerSeryjny, double ladownoscMax)
    {
        Masa = masa;
        Wysokosc = wysokosc;
        WagaKontenera = wagaKontenera;
        Glebokosc = glebokosc;
        NumerSeryjny = numerSeryjny;
        LadownoscMax = ladownoscMax;
    }

    public  virtual void EmptyZaladunek()
    {
        Masa = 0;
        Console.WriteLine($"Kontener {NumerSeryjny} został opróżniony.");
    }

    public virtual void Zaladuj(double weight)
    {
        if (weight <= LadownoscMax)
        {
            LadownoscMax = weight;
            Masa += weight;
            Console.WriteLine($"Kontener {NumerSeryjny} został załadowany ładunkiem o masie {weight} kg.");
        }
        else
        {
            Console.WriteLine($"Nie można załadować kontenera {NumerSeryjny} - przekroczona maksymalna ładowność.");
        }
    }

        
    }

