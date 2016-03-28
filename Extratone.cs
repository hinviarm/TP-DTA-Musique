using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    class Extratone : Musique, ListeType
    {
        public Extratone(List<Piste> ExtraListePiste) : base(ExtraListePiste) { }
        public int MonBpmMax
        {
            get
            {
                return 1100;
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
                return 1000;
            }

            set
            {
                MonBpmMin = value;
            }
        }
    }
}
