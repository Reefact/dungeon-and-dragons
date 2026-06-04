#region Usings declarations

using DungeonAndDragons.Domain.Core;

#endregion

namespace DungeonAndDragons.CLI.__tmp;

public sealed class PersonnagesImp : Personnages {

    /// <inheritdoc />
    public Personnage GetById(PersonnageId id) {
        ArgumentNullException.ThrowIfNull(id);

        ValeurDeCaractéristique force            = ValeurDeCaractéristique.From(Caractéristique.Force, 14);
        ValeurDeCaractéristique dextérité        = ValeurDeCaractéristique.From(Caractéristique.Dextérité, 8);
        ValeurDeCaractéristique constitution     = ValeurDeCaractéristique.From(Caractéristique.Constitution, 15);
        ValeurDeCaractéristique intelligence     = ValeurDeCaractéristique.From(Caractéristique.Intelligence, 10);
        ValeurDeCaractéristique sagesse          = ValeurDeCaractéristique.From(Caractéristique.Sagesse, 16);
        ValeurDeCaractéristique charisme         = ValeurDeCaractéristique.From(Caractéristique.Sagesse, 12);
        Caractéristiques        caractéristiques = new(force, dextérité, constitution, intelligence, sagesse, charisme);
        Personnage              clerc            = new(id, "Dorin Grunvar", Classe.Clerc, Niveau.From(1), caractéristiques);

        return clerc;
    }

}