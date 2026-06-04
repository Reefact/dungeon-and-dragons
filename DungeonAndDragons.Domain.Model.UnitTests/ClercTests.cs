#region Usings declarations

using NFluent;

#endregion

namespace DungeonAndDragons.Domain.Model.UnitTests {

    public class ClercTests {

        [Theory(DisplayName = "Le clerc ne maîtrise pas ces caractéristiques")]
        [InlineData(Caractéristique.Dextérité)]
        [InlineData(Caractéristique.Constitution)]
        [InlineData(Caractéristique.Force)]
        [InlineData(Caractéristique.Intelligence)]
        public void Test_01(Caractéristique caractéristique) {
            // Exercise & verify
            Check.That(Classe.Clerc.ConfèreLaMaîtriseDeCetteCaractéristiquePourLesJetsDeSauvegarde(caractéristique)).IsFalse();
        }

        [Theory(DisplayName = "Le clerc maîtrise ces caractéristiques")]
        [InlineData(Caractéristique.Charisme)]
        [InlineData(Caractéristique.Sagesse)]
        public void Test_02(Caractéristique caractéristique) {
            // Exercise & verify
            Check.That(Classe.Clerc.ConfèreLaMaîtriseDeCetteCaractéristiquePourLesJetsDeSauvegarde(caractéristique)).IsTrue();
        }

        [Fact(DisplayName = "Have a representative string representation")]
        public void Test_03() {
            Check.That(Classe.Clerc.ToString()).IsEqualTo("Clerc");
        }

    }

}