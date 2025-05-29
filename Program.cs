namespace ConsoleApp9
{
    class Program
    {
            static void Main()
            {
                var sefer = SeferOlustur();

                while (true)
                {
                    KoltukGosterici.KoltuklariGoster(sefer.Otobus);

                    Console.Write("Koltuk numarası: ");
                    int koltukNo = int.Parse(Console.ReadLine());

                    Console.Write("Yolcu adı: ");
                    string ad = Console.ReadLine();

                    sefer.RezervasyonYap(koltukNo, ad);

                    Console.Write("Devam edilsin mi? (e/h): ");
                    if (Console.ReadLine().ToLower() != "e") break;
                }

                Console.Clear();
                sefer.BiletYazdir();
            }

            static Sefer SeferOlustur()
            {
                Console.WriteLine(" Mevcut Şehirler:");
                for (int i = 0; i < SehirListesi.Sehirler.Count; i++)
                    Console.WriteLine($"{i + 1}. {SehirListesi.Sehirler[i]}");

                Console.Write("Kalkış şehri numarası: ");
                int kalkisIndex = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Varış şehri numarası: ");
                int varisIndex = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Sefer tarihi (gg.aa.yyyy): ");
                DateTime tarih = DateTime.Parse(Console.ReadLine());

                var otobus = new Otobus(20);

                return new SehirlerarasiSefer(
                    SehirListesi.Sehirler[kalkisIndex],
                    SehirListesi.Sehirler[varisIndex],
                    tarih,
                    otobus
                );
            }
        }

    }
