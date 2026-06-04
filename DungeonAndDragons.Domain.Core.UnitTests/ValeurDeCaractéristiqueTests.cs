#region Usings declarations

using NFluent;

#endregion

namespace DungeonAndDragons.Domain.Core.UnitTests {

    public class ValeurDeCaractéristiqueTests {

        [Theory]
        [InlineData(3, -4)]
        [InlineData(4, -3)]
        [InlineData(5, -3)]
        [InlineData(6, -2)]
        [InlineData(7, -2)]
        [InlineData(8, -1)]
        [InlineData(9, -1)]
        [InlineData(10, 0)]
        [InlineData(11, 0)]
        [InlineData(12, 1)]
        [InlineData(13, 1)]
        [InlineData(14, 2)]
        [InlineData(15, 2)]
        [InlineData(16, 3)]
        [InlineData(17, 3)]
        [InlineData(18, 4)]
        [InlineData(19, 4)]
        [InlineData(20, 5)]
        public void Tes_01(int valeurDeCaractéristique, int expectedModificateur) {
            // Setup
            Caractéristique         anyCaractéristique       = Caractéristique.Constitution;
            ValeurDeCaractéristique valeurDeCaractéristique_ = ValeurDeCaractéristique.From(anyCaractéristique, valeurDeCaractéristique);

            // Exercise

            // Verify
            Check.That(valeurDeCaractéristique_.Modificateur).IsEqualTo(expectedModificateur);
        }

    }

}