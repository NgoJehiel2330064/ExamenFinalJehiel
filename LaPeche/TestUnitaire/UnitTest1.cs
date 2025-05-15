using LaPeche;

namespace TestUnitaire
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true)]
        public void MeilleurEmbarcationPeche(bool resultatAttendu)
        {
            EmbarcationPeche embarcationPeche = new EmbarcationPeche("embarque",8,10,8,200);
            EmbarcationPeche embarcationPeche1 = new EmbarcationPeche("embarque",8,9,8,200);


            bool result = embarcationPeche > embarcationPeche1;
            //Vérifier si le résultat attendu et le résultat obtenu correspondent 
            Assert.Equal(resultatAttendu, result);
        }



        [Theory]
        [InlineData(true)]
        public void MeilleurEmbarcationPneumatique(bool resultatAttendu)
        {
           
            EmbarcationPneumatique embarcationPneumatique = new EmbarcationPneumatique("Embarque", 5, 7, 8, 150);
            EmbarcationPneumatique embarcationPneumatique1 = new EmbarcationPneumatique("Embarque", 5, 5, 8, 150);


            bool result = embarcationPneumatique > embarcationPneumatique1;
            //Vérifier si le résultat attendu et le résultat obtenu correspondent 
            Assert.Equal(resultatAttendu, result);
        }

    }
}