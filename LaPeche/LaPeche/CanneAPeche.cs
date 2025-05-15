using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public class CanneAPeche
    {
        public string Marque { get; set; }
        public int Flexibilite { get; set; }
        public int Resistance { get; set; }

        public CanneAPeche()
        {
            Marque = "Canac";
            Flexibilite = Program.rand.Next(1, 11);
            Resistance = Program.rand.Next(1, 11);
        }

        public static bool operator >(CanneAPeche a, CanneAPeche b)
        {
            return a.Flexibilite + a.Resistance > b.Flexibilite + b.Resistance;
        }

        public static bool operator <(CanneAPeche a, CanneAPeche b)
        {
            return a.Flexibilite + a.Resistance < b.Flexibilite + b.Resistance;
        }


        public override string ToString()
        {
            return $"Marque : {Marque} | Flexibilité : {Flexibilite} | Résistance : {Resistance}\n";
        }
    }
}
