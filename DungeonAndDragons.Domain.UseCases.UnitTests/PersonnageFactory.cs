#region Usings declarations

using DungeonAndDragons.Domain.Core;

#endregion

namespace DungeonAndDragons.Domain.UseCases.UnitTests;

internal static class PersonnageFactory {

    #region Static members

    public static Personnage CreateDorin() {
        PersonnageId            personnageId     = PersonnageId.From(Guid.Parse("C7B2D1D1-E8A7-4D10-BA18-85E745C174D5"));
        ValeurDeCaractéristique force            = ValeurDeCaractéristique.From(Caractéristique.Force, 14);
        ValeurDeCaractéristique dextérité        = ValeurDeCaractéristique.From(Caractéristique.Dextérité, 8);
        ValeurDeCaractéristique constitution     = ValeurDeCaractéristique.From(Caractéristique.Constitution, 15);
        ValeurDeCaractéristique intelligence     = ValeurDeCaractéristique.From(Caractéristique.Intelligence, 10);
        ValeurDeCaractéristique sagesse          = ValeurDeCaractéristique.From(Caractéristique.Sagesse, 16);
        ValeurDeCaractéristique charisme         = ValeurDeCaractéristique.From(Caractéristique.Sagesse, 12);
        Caractéristiques        caractéristiques = new(force, dextérité, constitution, intelligence, sagesse, charisme);
        Personnage              dorin            = new(personnageId, "Dorin", Classe.Clerc, Niveau.From(1), caractéristiques);

        return dorin;
    }

    #endregion

}