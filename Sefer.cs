using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiBiletix
{
    public abstract class Sefer : Rezervasyon
    {
        public string Nereden { get; set; }
        public string Nereye { get; set; }
        public DateTime Tarih { get; set; }
        public Otobus Otobus { get; set; }

        public Sefer()
        {
            Otobus = new Otobus(20); 
        }

        public virtual bool RezervasyonYap(int koltukNo)
        {
            return Otobus.KoltukAyir(koltukNo);
        }

        public void KoltukDurumlariniGoster()
        {
            Otobus.KoltukDurumuYazdir();
        }

        public override string ToString()
        {
            return $"{GetType().Name} Seferi: {Nereden} → {Nereye} - {Tarih:d}";
        }
    }

    public class Sehirici : Sefer
    {
        public static List<string> Ilceler = new List<string>
    {
        "Gaziantep Merkez", "Şehitkamil", "Şahinbey", "İslahiye", "Nurdağı", "Nizip", "Araban", "Oğuzeli"
    };
    }

    public class Sehirlerarasi : Sefer
    {
        public static List<string> Sehirler = new List<string>
        {
            "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", 
            "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", 
            "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İçel (Mersin)", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", 
            "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu",
            "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak", "Aksaray",
            "Bayburt", "Karaman", "Kırıkkale", "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
        };
}
}
