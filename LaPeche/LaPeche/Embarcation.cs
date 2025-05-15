using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public abstract class Embarcation
    {
        public string Nom { get; set; }
        public int NombresPlace { get; set; }
        public int Vitesse { get; set; }
        public int Confort { get; set; }
        public int Poids { get; set; }

        public Embarcation()
        {
            Nom = "Embarcation";
            NombresPlace = 8;
            Vitesse = Program.rand.Next(1, 11);
            Confort = Program.rand.Next(1, 11);
            Poids = Program.rand.Next(50, 151);
        }

        public static bool operator >(Embarcation a, Embarcation b)
        {
            return a.Vitesse + a.Confort > b.Vitesse + b.Confort;
        }

        public static bool operator <(Embarcation a, Embarcation b)
        {
            return a.Vitesse + a.Confort < b.Vitesse + b.Confort;
        }


        public override string ToString()
        {
            return $"Nom : {Nom} | Nombres de Places : {NombresPlace} | Vitesse : {Vitesse} | Confort : {Confort} | Poids : {Poids}";
        }
    }
}
