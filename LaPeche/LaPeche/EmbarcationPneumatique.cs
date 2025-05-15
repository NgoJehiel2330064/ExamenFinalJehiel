using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public class EmbarcationPneumatique : Embarcation
    {
        public EmbarcationPneumatique() : base()
        {
            Nom = "Embarcation Pneumatique";
            Vitesse = Program.rand.Next(1, 8);
            Poids = Program.rand.Next(80, 150);
            NombresPlace = 5;
        }

        public EmbarcationPneumatique(string nom, int nbPlace, int vitesse, int confort, int poids) : base()
        {

            Vitesse = Program.rand.Next(1, 8);
            Poids = Program.rand.Next(80, 150);
            NombresPlace = 5;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
