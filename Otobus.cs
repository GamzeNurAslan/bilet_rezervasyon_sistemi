using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiBiletix
{
        public class Otobus
        {
            private Koltuk[] koltuklar;
        public bool KoltukDurumu(int koltukNo)
        {
            if (koltukNo < 1 || koltukNo > koltuklar.Length)
                return true; 
            return koltuklar[koltukNo - 1].DoluMu;
        }

        public Otobus(int koltukSayisi)
            {
                koltuklar = new Koltuk[koltukSayisi];
                for (int i = 0; i < koltukSayisi; i++)
                {
                    koltuklar[i] = new Koltuk { Numara = i + 1, DoluMu = false };
                }
            }

            public bool KoltukAyir(int no)
            {
                if (no < 1 || no > koltuklar.Length) return false;
                if (koltuklar[no - 1].DoluMu) return false;

                koltuklar[no - 1].DoluMu = true;
                return true;
            }

            public void KoltukDurumuYazdir()
            {
                foreach (var koltuk in koltuklar)
                {
                    Console.WriteLine($"Koltuk {koltuk.Numara}: {(koltuk.DoluMu ? "Dolu" : "Boş")}");
                }
            }
        }
}
