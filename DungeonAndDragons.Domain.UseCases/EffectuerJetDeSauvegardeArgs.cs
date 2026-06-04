#region Usings declarations

using DungeonAndDragons.Domain.Model;

#endregion

namespace DungeonAndDragons.Domain.UseCases;

public sealed class EffectuerJetDeSauvegardeArgs {

    #region Constructors & Destructor

    public EffectuerJetDeSauvegardeArgs(PersonnageId personnageId, Caractéristique caractéristique) {
        ArgumentNullException.ThrowIfNull(personnageId);

        PersonnageId    = personnageId;
        Caractéristique = caractéristique;
    }

    #endregion

    public PersonnageId    PersonnageId    { get; }
    public Caractéristique Caractéristique { get; }

}