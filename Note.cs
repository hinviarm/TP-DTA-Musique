using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TpMusique
{
    [Serializable]
    class Note : System.Runtime.Serialization.ISerializable
    {
        public double Duree { get; set; }
        public int Frequence { get; set; }

        public Note(double DureeEnt, int MaFreq)
        {
            Duree = DureeEnt;
            Frequence = MaFreq;
        }
        public void Jouer()
        {
            Console.Beep(Frequence, (int)Math.Abs(Duree*1000));
            Console.WriteLine(Frequence + ":" + Duree);
        }
        public void Jouer(double DureeEnt, int MaFreq)
        {
            Console.Beep(MaFreq, (int)DureeEnt*1000);
            Console.WriteLine(MaFreq + ":" + DureeEnt);
        }
        public Note(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            Duree = (double)info.GetValue("Liste", typeof(double));
            Frequence = (int)info.GetValue("Liste", typeof(int));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("Duree", Duree);
            info.AddValue("Frequence", Frequence);
        }
    }
}
