using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;
using SignWaveTest;

namespace TpMusique
{
    class Program
    {
        static void Main(string[] args)
        {
            //AfficherAncienMenu();
            //JouerChansonSimple();
            //JouerChansonAvecStyle();
            

            EnregisterEtJouerChanson();

            //SineOccilator MonOcci = new SineOccilator(44100);
            //MonOcci.GetNext(10);
           // SerialList();
            //DeSerialList();

            Console.ReadKey();
        }
        static void SerialList()
        {


             System.IO.FileStream fs = new System.IO.FileStream("Liste.data", System.IO.FileMode.Create);
            //System.IO.FileStream fs = new System.IO.FileStream("Liste.data", System.IO.File.);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                var Nom = Synthetizer();
                formatter.Serialize(fs, Nom);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

        }
        static void DeSerialList()
        {
            Piste LaPiste;

            // Open the file containing the data that you want to deserialize.
            System.IO.FileStream fs = new System.IO.FileStream("Liste.data", System.IO.FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                LaPiste = (Piste)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.
            //foreach (Note de in LaPiste.LPiste)
            //{
            //    de.Jouer();
            //}

            IJouer musique = PisteWrapper(LaPiste);
            musique.Jouer();
        }
        static void AfficherAncienMenu()
        {
            string MesNotes;
            string TypeM;
            int MaFreq;
            int BpmMin;
            int BpmMax;
            int VarPiste = 1;
            double MaDuree;
            List<Note> TPiste = new List<Note>();
            List<Piste> TMusique = new List<Piste>();
            string[] values = Enum.GetNames(typeof(Frequence));
            string[] values2 = Enum.GetNames(typeof(StyleMusique));
            Console.WriteLine("Choisissez votre style de musique\n");
            foreach (string s in values2) { Console.WriteLine(s); }
            TypeM = Console.ReadLine();
            //Console.WriteLine(" Entrez le BPM min");
            //BpmMin = int.Parse(System.Console.ReadLine());
            //Console.WriteLine(" Entrez le BPM Max");
            //BpmMax = int.Parse(System.Console.ReadLine());

            do
            {
                Console.WriteLine("Bonjour Veillez Choisir Les notes de la piste" + VarPiste + "\n");
                VarPiste++;
                foreach (string s in values) { Console.WriteLine(s); }
                do
                {
                    Console.WriteLine("Entrez la note");
                    MesNotes = Console.ReadLine();
                    //Console.WriteLine("Entrez sa frequence\n");
                    //MaFreq = int.Parse(System.Console.ReadLine());
                    /*Frequence mafreq = (Frequence)Enum.Parse(typeof(Frequence), "DO");
                    MaFreq = (int)mafreq;*/

                    MaFreq = (int)Enum.Parse(typeof(Frequence), MesNotes.ToUpper());

                    Console.WriteLine("Entrez sa duree\n");
                    MaDuree = Double.Parse(System.Console.ReadLine());
                    Note Manote = new Note(MaDuree, MaFreq);
                    TPiste.Add(Manote);
                    Console.WriteLine("Voulez Vous entrer une autre note?\n tapez oui ou non");
                } while (Console.ReadLine().ToLower() == "oui");
                //Piste LaPiste = new Piste(TPiste, BpmMin, BpmMax);
                Piste LaPiste = new Piste(TPiste);
                TMusique.Add(LaPiste);
                Console.WriteLine("Voulez Vous ajouter une piste?\n tapez oui ou non");

            } while (Console.ReadLine().ToLower() == "oui");

            switch (TypeM.ToLower())
            {
                case "extratone":
                    Extratone MonExtra = new Extratone(TMusique);
                    MonExtra.Jouer(MonExtra.MonBpmMin, MonExtra.MonBpmMax);
                    break;
                case "hiphop":
                    HipPop MonHipHop = new HipPop(TMusique);
                    MonHipHop.Jouer(MonHipHop.MonBpmMin, MonHipHop.MonBpmMax);
                    break;
                case "salsa":
                    Salsa MaSalsa = new Salsa(TMusique);
                    MaSalsa.Jouer(MaSalsa.MonBpmMin, MaSalsa.MonBpmMax);
                    break;
                case "tango":
                    Tango MonTango = new Tango(TMusique);
                    MonTango.Jouer(MonTango.MonBpmMin, MonTango.MonBpmMax);
                    break;
                case "techno":
                    Techno MaTechno = new Techno(TMusique);
                    MaTechno.Jouer(MaTechno.MonBpmMin, MaTechno.MonBpmMax);
                    break;
                default:
                    Console.WriteLine("Vous n'avez pas choisi de type valide ressaiyez ou tapez non pour quitter \n");
                    break;
            }
        }
        static void JouerChansonSimple()
        {
            var notes = new List<Note>();
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.RE));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.MI));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.RE));

            var pistes = new List<Piste>();
            pistes.Add(new Piste(notes));

            var musique = new Extratone(pistes);

            musique.Jouer();
        }
        static void JouerChansonAvecStyle()
        {
            var notes = new List<Note>();
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.RE));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.MI));
            notes.Add(new Note(1, (int)Frequence.DO));
            notes.Add(new Note(1, (int)Frequence.RE));

            var pistes = new List<Piste>();
            pistes.Add(new Piste(notes));

            IJouer musique;

            string style;
            string[] stylesDispo = Enum.GetNames(typeof(StyleMusique));

            Console.WriteLine("styles de musique:");
            foreach (string styleDispo in stylesDispo) { Console.WriteLine("-"+styleDispo); }
            do
            {
                Console.WriteLine("Choisissez votre style:");
                style = Console.ReadLine().ToLower();
            } while(stylesDispo.Contains(style));

            musique = MusiqueFactory.CreateMusique(pistes, style);
            musique.Jouer();
        }

        static Piste Synthetizer()
        {
             DateTime time;
            ConsoleKey key;
            var notes = new List<Note>();
            while ((key = Console.ReadKey().Key) != ConsoleKey.Escape)
            {
                time = DateTime.Now;
                switch (key)
                {
                    case ConsoleKey.C:
                        //TimeSpan holdTime = DateTime.Now.Subtract(time);
                        //var MaNote = new Note(holdTime.TotalMilliseconds, (int)Frequence.DO);
                        var MaNote = new Note(1, (int)Frequence.DO);
                        notes.Add(MaNote);
                        MaNote.Jouer();
                        //time = DateTime.Now;
                        break;
                    case ConsoleKey.Q:
                        var MaNote1 = new Note(1, (int)Frequence.DODiese);
                        notes.Add(MaNote1);
                        MaNote1.Jouer();
                        break;
                    case ConsoleKey.D:
                        var MaNote2 = new Note(1, (int)Frequence.RE);
                        notes.Add(MaNote2);
                        MaNote2.Jouer();
                        break;
                    case ConsoleKey.S:
                        var MaNote3 = new Note(1, (int)Frequence.REDiese);
                        notes.Add(MaNote3);
                        MaNote3.Jouer();
                        break;
                    case ConsoleKey.E:
                        var MaNote4 = new Note(1, (int)Frequence.MI);
                        notes.Add(MaNote4);
                        MaNote4.Jouer();
                        break;
                    case ConsoleKey.F:
                        var MaNote5 = new Note(1, (int)Frequence.FA);
                        notes.Add(MaNote5);
                        MaNote5.Jouer();
                        break;
                    case ConsoleKey.H:
                        var MaNote6 = new Note(1, (int)Frequence.FADiese);
                        notes.Add(MaNote6);
                        MaNote6.Jouer();
                        break;
                    case ConsoleKey.G:
                        var MaNote7 = new Note(1, (int)Frequence.SOL);
                        notes.Add(MaNote7);
                        MaNote7.Jouer();
                        break;
                    case ConsoleKey.J:
                        var MaNote8 = new Note(1, (int)Frequence.SOLDiese);
                        notes.Add(MaNote8);
                        MaNote8.Jouer();
                        break;
                    case ConsoleKey.A:
                        var MaNote9 = new Note(1, (int)Frequence.LA);
                        notes.Add(MaNote9);
                        MaNote9.Jouer();
                        break;
                    case ConsoleKey.K:
                        var MaNoteA = new Note(1, (int)Frequence.LADiese);
                        notes.Add(MaNoteA);
                        MaNoteA.Jouer();
                        break;
                    case ConsoleKey.B:
                        var MaNoteB = new Note(1, (int)Frequence.SI);
                        notes.Add(MaNoteB);
                        MaNoteB.Jouer();
                        break;
                    case ConsoleKey.Spacebar:
                        var MaNoteC = new Note(1, 0);
                        notes.Add(MaNoteC);
                        MaNoteC.Jouer();
                        break;            
                    default:
                        break;
                }
            }
            return new Piste(notes);
        }
        static IJouer PisteWrapper(Piste piste)
        {
            IJouer musique;

            string style;
            string[] stylesDispo = Enum.GetNames(typeof(StyleMusique));

            Console.WriteLine("styles de musique:");
            foreach (string styleDispo in stylesDispo) { Console.WriteLine("-" + styleDispo); }
            do
            {
                Console.WriteLine("Choisissez votre style:");
                style = Console.ReadLine().ToLower();
            } while (stylesDispo.Contains(style));

            var pistes = new List<Piste>();
            pistes.Add(piste);

            Console.WriteLine("Voulez vous Ajouter une deuxième piste?\n tapez echap pour Non et n'importe quel touche pour oui\n");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {
                int n = 3;
                pistes.Add(Synthetizer());
                Console.WriteLine("Voulez vous Ajouter une "+n+"ème piste?\n tapez echap pour Non et n'importe quel touche pour oui\n");
                n++;
            }

            musique = MusiqueFactory.CreateMusique(pistes, style);
            return musique;
        }
        static void EnregisterEtJouerChanson() 
        {
            IJouer musique = PisteWrapper(Synthetizer());
            musique.Jouer();
        }

        enum Frequence
        {
            DO = 262, DODiese = 277, RE = 294, REDiese = 311, MI = 330, FA = 349, FADiese = 370, SOL = 392,
            SOLDiese = 415, LA = 440, LADiese = 466, SI = 494,
        };

        enum StyleMusique
        {
            Extratone,HipHop,Salsa,Tango,Techno,
        }
    }
}
