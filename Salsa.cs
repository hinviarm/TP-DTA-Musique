using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    class Salsa : Musique, ListeType
    {
        public Salsa(List<Piste> SalsaListePiste):base(SalsaListePiste) { }
        public int MonBpmMax
        {
            get
            {
                return 220;
            }

            set
            {
                MonBpmMax = value;
            }
        }

        public int MonBpmMin
        {
            get
            {
                return 150; 
            }

            set
            {
                MonBpmMin = value;
            }
        }

    }
}
