namespace ConsoleApp9
{
    public class Otobus
    {
        public Koltuk[] Koltuklar { get; set; }

        public Otobus(int koltukSayisi)
        {
            Koltuklar = new Koltuk[koltukSayisi];
            for (int i = 0; i < koltukSayisi; i++)
                Koltuklar[i] = new Koltuk { No = i + 1 };
        }
    }

}
