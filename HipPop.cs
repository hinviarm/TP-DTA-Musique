using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    class HipPop : Musique, ListeType
    {
        public HipPop(List<Piste> HipHopListePiste) : base(HipHopListePiste) { }
        public int MonBpmMax
        {
            get
            {
                return 100;
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
                return 80;
            }

            set
            {
                MonBpmMin = value;
            }
        }

       
    }
}
