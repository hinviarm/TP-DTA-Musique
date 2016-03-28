using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    static class MusiqueFactory
    {
        public static IJouer CreateMusique(List<Piste> pistes, string style)
        {
            IJouer musique;
            switch (style)
            {
                case "extratone":
                    musique = new Extratone(pistes);
                    break;
                case "hiphop":
                    musique = new HipPop(pistes);
                    break;
                case "salsa":
                    musique = new Salsa(pistes);
                    break;
                case "tango":
                    musique = new Tango(pistes);
                    break;
                case "techno":
                    musique = new Techno(pistes);
                    break;
                default:
                    throw new Exception("unknown style");
            }
            return musique;
        }
    }
}
