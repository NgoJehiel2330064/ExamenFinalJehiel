namespace LaPeche
{
    internal class Program
    {
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            Simulateur simulateur = new Simulateur();
            simulateur.DemmarrerSimulateur();
        }
    }
}
