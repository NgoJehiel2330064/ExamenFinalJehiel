using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public enum Difficulte
    {
        Facile,
        Moyen,
        Difficile
    };
    public class Poisson
    {
        public string Nom { get; set; }
        public Difficulte Difficulte { get; set; }
        public int Force { get; set; }
        public int Vitesse { get; set; }
        public int Experience { get; set; }
        public int Poids { get; set; }


        public Poisson(Difficulte difficulte)
        {
            Nom = ChoisirNom();
            if (difficulte == Difficulte.Facile)
            {
                Experience = Program.rand.Next(2, 11);
                Force = 3;
                Vitesse = Program.rand.Next(2, 4);
            }
            else if (difficulte == Difficulte.Moyen)
            {
                Experience = Program.rand.Next(11, 26);
                Force = 4;
                Vitesse = Program.rand.Next(5, 7);
            }
            else
            {
                Experience = Program.rand.Next(26, 51);
                Force = 5;
                Vitesse = Program.rand.Next(7, 11);
            }

            Poids = Experience * 2;

        }


        public Poisson()
        {
            int aleatoire = Program.rand.Next(3);

            Nom = ChoisirNom();
            if (aleatoire == 0)
            {
                Difficulte = Difficulte.Facile;
                Experience = Program.rand.Next(2, 11);
                Force = 3;
                Vitesse = Program.rand.Next(2, 4);
            }
            else if (aleatoire == 1)
            {
                Difficulte = Difficulte.Moyen;
                Experience = Program.rand.Next(11, 26);
                Force = 4;
                Vitesse = Program.rand.Next(5, 7);
            }
            else
            {
                Difficulte = Difficulte.Difficile;
                Experience = Program.rand.Next(26, 51);
                Force = 5;
                Vitesse = Program.rand.Next(7, 11);
            }

            Poids = Experience * 2;

        }


        public static bool operator >(Poisson a, Poisson b)
        {
            return a.Poids > b.Poids;
        }

        public static bool operator <(Poisson a, Poisson b)
        {
            return a.Poids < b.Poids;
        }

        public string ChoisirNom()
        {
            string[] noms = { "Doré", "Brochet", "Morue", "Sébaste", "Truie" };
            return noms[Program.rand.Next(noms.Length)];
        }


        public override string ToString()
        {
            return $"\n{Nom}\n -----------------------------\n Force de {Force}      Vitesse de {Vitesse}\n {Experience} expériences   Poids {Poids}\n";
        }

    }


}
