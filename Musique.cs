using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TpMusique
{
    class Musique : IJouer
    {
        public List<Piste> LPisteP;

        public Musique()
        {
            LPisteP = new List<Piste>();
        }
        public Musique(List<Piste> MalistePiste)
        {
            LPisteP = MalistePiste;
        }
        public void Jouer()
        {
            foreach (Piste MaPiste in LPisteP.AsParallel())
            {
                //MaPiste.Jouer();
                //var notes = new List<Note>();
                //notes.Add(new Note(1, 262));
                //notes.Add(new Note(1, 262));
                //notes.Add(new Note(1, 262));
                //notes.Add(new Note(1, 294));
                //notes.Add(new Note(1, 262));
                //notes.Add(new Note(1, 330));
                //notes.Add(new Note(1, 262));
                //notes.Add(new Note(1, 294));

                
                //var piste= new Piste(notes);
                //piste.Jouer();
                Task TachJouer = Task.Factory.StartNew(() => MaPiste.Jouer());
            }
        }
        public void Jouer(int BpmMinEnt, int BpmMaxEnt)
        {
            foreach (Piste MaPiste in LPisteP.AsParallel())
            {
                MaPiste.Jouer(BpmMinEnt, BpmMaxEnt);
            }
        }
    }
}
