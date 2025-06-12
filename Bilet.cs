using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiBiletix
{
        public class Bilet
        {
            public Sefer Sefer { get; set; }
            public Yolcu Yolcu { get; set; }
            public int KoltukNo { get; set; }

            public override string ToString()
            {
                return $"Bilet - {Yolcu}, Koltuk No: {KoltukNo}, {Sefer}";
            }
        }
    }

