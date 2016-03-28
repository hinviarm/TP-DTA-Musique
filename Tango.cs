using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    class Tango : Musique, ListeType
    {
        public Tango(List<Piste> TangolistePiste):base(TangolistePiste)
        {          
        }
        public int MonBpmMax
        {
            get
            {
                return 56;
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
                return 50;
            }

            set
            {
                MonBpmMin = value;
            }
        }

        
    }
}
