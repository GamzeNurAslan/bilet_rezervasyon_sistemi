namespace ConsoleApp9
{
    public abstract class Sefer : Rezervasyon
    {
            public string Kalkis { get; set; }
            public string Varis { get; set; }
            public DateTime Tarih { get; set; }
            public Otobus Otobus { get; set; }

            public Sefer(string kalkis, string varis, DateTime tarih, Otobus otobus)
            {
                Kalkis = kalkis;
                Varis = varis;
                Tarih = tarih;
                Otobus = otobus;
            }

            public virtual void RezervasyonYap(int koltukNo, string yolcuAdi)
            {
                if (!Otobus.Koltuklar[koltukNo - 1].DoluMu)
                {
                    Otobus.Koltuklar[koltukNo - 1].DoluMu = true;
                    Otobus.Koltuklar[koltukNo - 1].YolcuAdi = yolcuAdi;
                    Console.WriteLine($"Koltuk {koltukNo} başarıyla rezerve edildi.");
                }
                else
                {
                    Console.WriteLine("Bu koltuk dolu.");
                }
            }

            public virtual void BiletYazdir()
            {
                foreach (var koltuk in Otobus.Koltuklar.Where(k => k.DoluMu))
                {
                    Console.WriteLine($"{koltuk.YolcuAdi} - Koltuk: {koltuk.No} | Sefer: {Kalkis} → {Varis}");
                }
            }
        }
}
    
