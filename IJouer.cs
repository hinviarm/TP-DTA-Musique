using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    interface IJouer
    {
        void Jouer();
        void Jouer(int BpmMinEnt, int BpmMaxEnt);
    }
}
