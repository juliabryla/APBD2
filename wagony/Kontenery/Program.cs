
using wagony;
using System;
class Program
{
    static void Main(string[] args)
    {
        
        Kontener Płyny = new L(100, 10, 200, 5, "KON-L-1", 300, true);
        Kontener Gazy = new G(300, 11, 100, 7, "KON-G-1", 400,1016);
        Kontener Chłodniczy = new C(200, 5, 200, 7, "KON-C-1", 250, "mięso", -15);
        Kontener Płyny2 = new L(100, 10, 200, 5, "KON-L-2", 300, true);
        Kontener Gazy2 = new G(300, 11, 100, 7, "KON-G-2", 400,1016);
        Kontener Chłodniczy3 = new C(200, 5, 200, 7, "KON-C-2", 250, "mięso", -15);
        Kontener Płyny3 = new L(100, 10, 200, 5, "KON-L-2", 300, true);
        Kontener Gazy3 = new G(300, 11, 100, 7, "KON-G-3", 400,1016);
        Kontener Chłodniczy4 = new C(200, 5, 200, 7, "KON-C-3", 250, "mięso", -15);
        List<Kontener> ListaKontenerow = new List<Kontener> { Płyny3, Gazy3 };
        Płyny.Zaladuj(100);
        Console.WriteLine($"Masa kontenera Płyny: {Płyny.Masa} kg");
        Gazy2.EmptyZaladunek();
        Console.WriteLine($"Masa kontenera {Gazy2.NumerSeryjny} to {Gazy2.Masa}");
        Kontenerowiec kontenerowiec1 = new Kontenerowiec(5, 3, 600);
        kontenerowiec1.DodajKontener(Płyny);
        kontenerowiec1.DodajKontener(Gazy);
        kontenerowiec1.WypiszInformacjeOStatku();
        kontenerowiec1.UsuńKontenerZeStatku(Gazy);
        kontenerowiec1.WypiszInformacjeOStatku();
        Kontenerowiec kontenerowiec2 = new Kontenerowiec(7, 5, 500);
        kontenerowiec1.PrzenieśKontenerMiedzyStatkami(kontenerowiec2,Płyny);
        kontenerowiec2.WypiszInformacjeOStatku();
        kontenerowiec2.ZaładujListęKontenerówNaStatek(ListaKontenerow);
        kontenerowiec2.WypiszInformacjeOStatku();
        kontenerowiec2.ZastąpKontenerNaStatku(Płyny,Chłodniczy);
        kontenerowiec2.WypiszInformacjeOKontenerze(Chłodniczy);
        
    }
      
}