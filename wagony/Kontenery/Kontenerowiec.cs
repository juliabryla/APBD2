using System;


namespace wagony
{
    public class Kontenerowiec
    {
        public List<Kontener> Kontenery { get; private set; }
        public double MaksymalnaPredkosc { get; private set; }
        public int MaksymalnaLiczbaKontenerow { get; private set; }
        public double MaksymalnaWagaKontenerow { get; private set; }

        public Kontenerowiec(double maksymalnaPredkosc, int maksymalnaLiczbaKontenerow, double maksymalnaWagaKontenerow)
        {
            Kontenery = new List<Kontener>();
            MaksymalnaPredkosc = maksymalnaPredkosc;
            MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
            MaksymalnaWagaKontenerow = maksymalnaWagaKontenerow;
        }

        public void DodajKontener(Kontener kontener)
        {
            if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
            {
                throw new InvalidOperationException("Kontenerowiec nie może pomieścić więcej kontenerów.");
            }

            if (ObliczWageKontenerow() + kontener.Masa > MaksymalnaWagaKontenerow)
            {
                throw new InvalidOperationException("Przekroczona maksymalna waga kontenerów, które mogą być przewożone.");
            }

            Kontenery.Add(kontener);
        }

        public void ZaładujKontenerNaStatek(Kontener kontener)
        {
            if (Kontenery.Contains(kontener))
            {
                throw new InvalidOperationException("Kontener już znajduje się na statku.");
            }

            if (Kontenery.Count >= MaksymalnaLiczbaKontenerow)
            {
                throw new InvalidOperationException("Brak miejsca na statku.");
            }

            Kontenery.Add(kontener);
        }

        public void ZaładujListęKontenerówNaStatek(List<Kontener> listaKontenerow)
        {
            foreach (var kontener in listaKontenerow)
            {
                ZaładujKontenerNaStatek(kontener);
            }
        }

        public void UsuńKontenerZeStatku(Kontener kontener)
        {
            if (!Kontenery.Contains(kontener))
            {
                throw new InvalidOperationException("Kontener nie znajduje się na statku.");
            }

            Kontenery.Remove(kontener);
        }

        public void RozładujKontener(Kontener kontener)
        {
            kontener.EmptyZaladunek();
        }

        public void ZastąpKontenerNaStatku(Kontener staryKontener, Kontener nowyKontener)
        {
            int index = Kontenery.IndexOf(staryKontener);
            if (index == -1)
            {
                throw new InvalidOperationException("Podany kontener nie znajduje się na statku.");
            }

            Kontenery[index] = nowyKontener;
        }

        public void PrzenieśKontenerMiedzyStatkami(Kontenerowiec innyKontenerowiec, Kontener kontener)
        {
            if (!Kontenery.Contains(kontener))
            {
                throw new InvalidOperationException("Podany kontener nie znajduje się na tym statku.");
            }

            UsuńKontenerZeStatku(kontener);
            innyKontenerowiec.ZaładujKontenerNaStatek(kontener);
        }

        public void WypiszInformacjeOKontenerze(Kontener kontener)
        {
            Console.WriteLine($"Typ kontenera: {kontener.GetType().Name}");
            Console.WriteLine($"Numer seryjny: {kontener.NumerSeryjny}");
            Console.WriteLine($"Masa kontenera: {kontener.Masa} kg");
            
        }

        public void WypiszInformacjeOStatku()
        {
            Console.WriteLine($"Maksymalna prędkość statku: {MaksymalnaPredkosc} węzłów");
            Console.WriteLine($"Aktualna liczba kontenerów na statku: {Kontenery.Count}");
            Console.WriteLine($"Maksymalna liczba kontenerów, które mogą być przewożone: {MaksymalnaLiczbaKontenerow}");
            Console.WriteLine($"Maksymalna waga kontenerów, które mogą być przewożone: {MaksymalnaWagaKontenerow} kg");
        }

        private double ObliczWageKontenerow()
        {
            double suma = 0;
            foreach (var kontener in Kontenery)
            {
                suma += kontener.Masa;
            }
            return suma;
        }
    }
}
