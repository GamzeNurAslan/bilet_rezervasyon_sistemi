namespace ConsoleApp9
{
    public static class KoltukGosterici
    {
        public static void KoltuklariGoster(Otobus otobus)
        {
            Console.Clear();
            Console.WriteLine("🪑 Koltuk Yerleşimi (Yeşil = Boş, Kırmızı = Dolu)");

            for (int i = 0; i < otobus.Koltuklar.Length; i++)
            {
                int x = (i % 4) * 6;
                int y = i / 4;

                Console.SetCursorPosition(x, y + 2);
                var koltuk = otobus.Koltuklar[i];

                Console.ForegroundColor = koltuk.DoluMu ? ConsoleColor.Red : ConsoleColor.Green;
                Console.Write($"[{koltuk.No}]");
            }

            Console.ResetColor();
            Console.SetCursorPosition(0, (otobus.Koltuklar.Length / 4) + 4);
        }
    }

}
