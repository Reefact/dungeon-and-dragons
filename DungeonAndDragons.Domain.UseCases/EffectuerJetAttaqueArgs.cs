#region Usings declarations

using DungeonAndDragons.Domain.Model;

#endregion

namespace DungeonAndDragons.Domain.UseCases;

public class LancerArmeArgs {

    #region Constructors & Destructor

    public LancerArmeArgs(PersonnageId personnageId, ArmeId armeId, Distance distanceDeLaCible) {
        ArgumentNullException.ThrowIfNull(personnageId);
        ArgumentNullException.ThrowIfNull(armeId);
        ArgumentNullException.ThrowIfNull(distanceDeLaCible);

        PersonnageId      = personnageId;
        ArmeId            = armeId;
        DistanceDeLaCible = distanceDeLaCible;
    }

    #endregion

    public PersonnageId PersonnageId      { get; }
    public ArmeId       ArmeId            { get; }
    public Distance     DistanceDeLaCible { get; }

}