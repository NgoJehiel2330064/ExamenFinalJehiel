using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public class Pecheur
    {
        public string Nom { get; set; }
        public int Niveau { get; set; }
        public int ExperiencePecheur { get; set; }
        public Poisson? PoissonTrophee { get; set; }
        public CanneAPeche? CanneAPeche { get; set; }
        public Embarcation? Embarcation { get; set; }
        public List<Poisson> PoissonsPecher { get; set; }


        public Pecheur()
        {
            Nom = "Jehiel";
            Niveau = DeterminerNiveau();
            PoissonTrophee = null;
            CanneAPeche = null;
            Embarcation = null;
            PoissonsPecher = new List<Poisson>();
        }

        public int DeterminerNiveau()
        {
            int niveau = (int)ExperiencePecheur / 100;
            if (niveau == 0)
                return 1;
            else
                return niveau;
        }

        public void AjouterPoissonPecher(Poisson poisson)
        {
            PoissonsPecher.Add(poisson);
        }

        public void AjouterPoissonTrophe(Poisson poisson)
        {
            PoissonTrophee = poisson;
        }

        public void GagnerExperience(int xp)
        {
            ExperiencePecheur += xp;
        }

        public override string ToString()
        {
            string message = PoissonTrophee == null ? "Vous n'avez aucun poisson trophée" : PoissonTrophee.ToString();
            string message1 = CanneAPeche == null ? "Vous n'avez aucune Canne à pêche" : $"Info sur la canne du pêcheur {Nom}\n{CanneAPeche.ToString()}";
            string message2 = Embarcation == null ? "Le choix du pêcheur est " : Embarcation.ToString();
            return $"\n{Nom} est au niveau : {Niveau} avec {ExperiencePecheur} d'expérience(S)\n Poisson Trophée : {message}\n{message1}\n{message2}\n";
        }


    }
}
