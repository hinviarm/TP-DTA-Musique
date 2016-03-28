using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TpMusique
{
    [Serializable]
    class Piste : System.Runtime.Serialization.ISerializable
    {
        public List<Note> LPiste = new List<Note>();
//        public int BpmMin { get; set; } = 1;
//        public int BpmMax { get; set; } = 1;
        public Piste(List<Note> Maliste)
        {
            LPiste = Maliste;
        }

        public Piste(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            LPiste = (List<Note>)info.GetValue("Liste", typeof(List<Note>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //if (info == null)
            //    throw new System.ArgumentNullException("info");
            //info.AddValue("Liste", LPiste);
            foreach(Note Mno in LPiste)
            {
                Mno.GetObjectData(info, context);
            }
        }

        //        public Piste(List<Note> Maliste, int BpmMinEnt, int BpmMaxEnt)
        //        {
        //            LPiste = Maliste;
        //            BpmMin = BpmMinEnt;
        //            BpmMax = BpmMaxEnt;
        //        }
        public void Jouer()
        {
            foreach(Note MaNote in LPiste)
            {
//                MaNote.Jouer(MaNote.Duree * ((BpmMin + BpmMax) / 2), MaNote.Frequence);
//                Thread.Sleep((BpmMax + BpmMin) / 2);
                MaNote.Jouer();
                Thread.Sleep(1000);
            }
        }
        public void Jouer(int BpmMinEnt, int BpmMaxEnt)
        {
            foreach (Note MaNote in LPiste)
            {
                MaNote.Jouer(MaNote.Duree * ((BpmMinEnt + BpmMaxEnt) / 2), MaNote.Frequence);
                Thread.Sleep((BpmMaxEnt + BpmMinEnt) / 2);
            }
        }
    }
}
