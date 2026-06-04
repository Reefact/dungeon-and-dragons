#region Usings declarations

using DungeonAndDragons.Domain.Core;

using Moq;

using NFluent;

#endregion

namespace DungeonAndDragons.Domain.UseCases.UnitTests {

    public class EffectuerJetDeSauvegardeTests {

        [Theory(DisplayName = "Le modificateur est appliqué aux jets de sauvegarde.")]
        [InlineData(Caractéristique.Constitution, 15)]
        [InlineData(Caractéristique.Dextérité, 12)]
        [InlineData(Caractéristique.Force, 15)]
        [InlineData(Caractéristique.Intelligence, 13)]
        public void Test1(Caractéristique caractéristique, int expectedResult) {
            // Setup
            Mock<Personnages> personnages = new();
            Personnage        dorin       = PersonnageFactory.CreateDorin();
            personnages.Setup(m => m.GetById(dorin.Id)).Returns(dorin);
            Mock<Joueur> joueur = new();
            joueur.Setup(m => m.LancerD20()).Returns(RésultatD20.FromInt32(13));
            EffectuerJetDeSauvegarde effectuerJetDeSauvegarde = new(personnages.Object, joueur.Object);

            Assert.True(dorin.NeMaitrisePas(caractéristique));

            // Exercise
            EffectuerJetDeSauvegardeArgs args            = new(dorin.Id, caractéristique);
            JetDeSauvegarde              jetDeSauvegarde = effectuerJetDeSauvegarde.Execute(args);

            // Verify
            Check.That(jetDeSauvegarde.Valeur).IsEqualTo(expectedResult);
        }

        [Theory(DisplayName = "Le modificateur ainsi que le bonus de maitrise sont appliqués aux jets de sauvegarde.")]
        [InlineData(Caractéristique.Sagesse, 18)]
        [InlineData(Caractéristique.Charisme, 16)]
        public void Test2(Caractéristique caractéristique, int expectedResult) {
            // Setup
            Mock<Personnages> personnages = new();
            Personnage        dorin       = PersonnageFactory.CreateDorin();
            personnages.Setup(m => m.GetById(dorin.Id)).Returns(dorin);
            Mock<Joueur> joueur = new();
            joueur.Setup(m => m.LancerD20()).Returns(RésultatD20.FromInt32(13));
            EffectuerJetDeSauvegarde effectuerJetDeSauvegarde = new(personnages.Object, joueur.Object);

            Assert.True(dorin.Maitrise(caractéristique));

            // Exercise
            EffectuerJetDeSauvegardeArgs args            = new(dorin.Id, caractéristique);
            JetDeSauvegarde              jetDeSauvegarde = effectuerJetDeSauvegarde.Execute(args);

            // Verify
            Check.That(jetDeSauvegarde.Valeur).IsEqualTo(expectedResult);
        }

    }

}