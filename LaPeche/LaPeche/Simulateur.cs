using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaPeche
{
    public class Simulateur
    {
        public Pecheur Pecheur { get; private set; }
        public Embarcation Embarcation { get; private set; }
        public CanneAPeche CanneAPeche { get; private set; }

        public Simulateur()
        {
            Pecheur = new Pecheur();
            CanneAPeche = new CanneAPeche();
            Pecheur.CanneAPeche = CanneAPeche;

        }

        public Embarcation[] GenererEmbarcation()
        {
            Console.Clear();

            Embarcation[] embarcations = new Embarcation[5];

            for (int i = 0; i < embarcations.Length; i++)
            {
                int choix = Program.rand.Next(2); // 0 ou 1
                if (choix == 0)
                    embarcations[i] = new EmbarcationPeche();
                else
                    embarcations[i] = new EmbarcationPneumatique();
            }

            return embarcations;
        }

        public Embarcation ChoisirMeilleur(Embarcation[] embarcations)
        {
            var MeilleurEmbarcation = embarcations[0];
            for (int i = 1; i < embarcations.Length; i++)
                if (embarcations[i] > MeilleurEmbarcation)
                    MeilleurEmbarcation = embarcations[i];

            return MeilleurEmbarcation;
        }

        public void DemmarrerSimulateur()
        {

            Console.WriteLine("Bienvenue dans le simulateur de pêche");
            Embarcation[] embarcations = GenererEmbarcation();
            Console.WriteLine();
            Console.WriteLine($"Voici la listes des {embarcations.Length} génerer");
            for (int i = 0; i < embarcations.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {embarcations[i]}\n");
            }
            Pecheur.Embarcation = ChoisirMeilleur(embarcations);
            Console.WriteLine($"Le meilleur des {embarcations.Length} est {Pecheur.Embarcation}");
            int choix = 0;
            do
            {
                Console.WriteLine("1 - Voir les informations Pecheur");
                Console.WriteLine("2 - Changer de Canne");
                Console.WriteLine("3 - Simuler une capture de poisson");
                Console.WriteLine("4 - Afficher la liste des poissons pêchés");
                Console.WriteLine("0 - Quitter");

                choix = Convert.ToInt32(Console.ReadLine());

                switch (choix)
                {
                    case 1: VoirInfoPecheur(); break;
                    case 2: ChangerCanne(); break;
                    case 3: SimulerCapture(); break;
                    case 4: AfficherPoissonPecher(); break;
                }

            } while (choix != 0);
            Console.Clear();

        }


        public void VoirInfoPecheur()
        {
            Console.WriteLine(Pecheur.ToString());
        }

        public CanneAPeche[] GenererCanne()
        {
            Console.Clear();

            CanneAPeche[] cannes = new CanneAPeche[4];

            for (int i = 0; i < cannes.Length; i++)
            {
                cannes[i] = new CanneAPeche();
            }
            return cannes;
        }




        public void ChangerCanne()
        {
            int nbFois = 0;
            if (nbFois == 0)
            {
                CanneAPeche[] cannes = new CanneAPeche[4];
                for (int i = 0; i < cannes.Length; i++)
                    cannes[i] = new CanneAPeche();

                var MeilleurCanne = cannes[0];
                for (int i = 1; i < cannes.Length; i++)
                {
                    if (cannes[i] > MeilleurCanne)
                        MeilleurCanne = cannes[i];
                }
                Console.WriteLine($"La canne de {Pecheur.Nom} à été changer: \nInformations de la nouvelle canne et c'est la meilleur :\n {MeilleurCanne.ToString()} ");
                nbFois++;
                Pecheur.CanneAPeche = MeilleurCanne;
            }
            else
            {
                Console.WriteLine($"Impossible de changer la canne car vous avez déjà changer de canne");
            }
        }


        public void SimulerCapture()
        {
            Poisson poisson = new Poisson();
            if (CapturerPoisson(poisson))
            {
                var meilleurPoisson = Pecheur.PoissonsPecher[0];
                for (int i = 1; i < Pecheur.PoissonsPecher.Count(); i++)
                {
                    if (Pecheur.PoissonsPecher[i] > meilleurPoisson)
                        meilleurPoisson = Pecheur.PoissonsPecher[i];
                }
                Pecheur.AjouterPoissonTrophe(meilleurPoisson);
            }
        }

        public bool CapturerPoisson(Poisson poisson)
        {
            int valeurPecheur = Program.rand.Next(1, Pecheur.CanneAPeche.Resistance) + Program.rand.Next(1, Pecheur.CanneAPeche.Flexibilite) + Program.rand.Next(1, Pecheur.Embarcation.Vitesse);
            int valeurPoisson = poisson.Force + poisson.Vitesse;

            if (valeurPecheur > valeurPoisson)
            {
                Console.WriteLine($"Bravo , vous venez de pêcher : \n{poisson.ToString()}");
                Pecheur.GagnerExperience(poisson.Experience);
                Pecheur.AjouterPoissonPecher(poisson);
                return true;
            }
            else
            {
                Console.WriteLine($"Dommage, vous venez de manquer un poisson pesant {poisson.Poids} livres. ");
                return false;
            }

        }

        public void AfficherPoissonPecher()
        {
            foreach (var p in Pecheur.PoissonsPecher)
            {
                Console.WriteLine(p + "\n");
            }
        }
    }
}
