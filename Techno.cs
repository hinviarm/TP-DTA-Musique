using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    class Techno : Musique, ListeType
    {
        public Techno(List<Piste> TechnoListePiste) : base(TechnoListePiste) { }
        public int MonBpmMax
        {
            get
            {
                return 145;
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
                return 125;
            }

            set
            {
                MonBpmMin = value;
            }
        }

        
    }
}
