using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiBiletix
{
    public interface Rezervasyon
    {
            bool RezervasyonYap(int koltukNo);
            void KoltukDurumlariniGoster();
        }

    }
