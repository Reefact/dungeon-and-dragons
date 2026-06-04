#region Usings declarations

using NFluent;

#endregion

namespace DungeonAndDragons.Domain.Core.UnitTests {

    public class BonusDeMaîtriseTests {

        [Theory(DisplayName = "Calcule le bonus de maîtrise à partir du niveau.")]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(4, 2)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        [InlineData(7, 3)]
        [InlineData(8, 3)]
        [InlineData(9, 4)]
        [InlineData(10, 4)]
        [InlineData(11, 4)]
        [InlineData(12, 4)]
        [InlineData(13, 5)]
        [InlineData(14, 5)]
        [InlineData(15, 5)]
        [InlineData(16, 5)]
        [InlineData(17, 6)]
        [InlineData(18, 6)]
        [InlineData(19, 6)]
        [InlineData(20, 6)]
        public void Test_01(int niveauDuPersonnage, int expectedBonusDeMaîtriseDeCaractéristique) {
            // Setup
            Caractéristique anyCaractéristique = Caractéristique.Constitution;
            Niveau          niveau             = Niveau.From(niveauDuPersonnage);
            // Exercise
            MaîtriseDeCaractéristique maîtriseDeCaractéristique = MaîtriseDeCaractéristique.Maîtrisée(anyCaractéristique, niveau);
            // Verify
            Check.That(maîtriseDeCaractéristique.Valeur).IsEqualTo(expectedBonusDeMaîtriseDeCaractéristique);
        }

    }

}