using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public class EmbarcationPeche : Embarcation
    {

        public EmbarcationPeche() : base()
        {
            Nom = "Embarcation Peche";
            Confort = Program.rand.Next(4, 11);
            Vitesse = Program.rand.Next(4, 11);
            Poids = Program.rand.Next(150, 301);
        }

        public EmbarcationPeche(string nom, int nbPlace, int vitesse, int confort, int poids) : base()
        {
            Nom = nom;
            Confort = confort;
            Poids = poids;
            Vitesse = vitesse;
            NombresPlace = nbPlace;
        }


        public override string ToString()
        {
            return base.ToString();
        }
    }
}
