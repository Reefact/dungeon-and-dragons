#region Usings declarations

using DungeonAndDragons.Domain.Core;

#endregion

namespace DungeonAndDragons.CLI.__tmp;

public sealed class ArmesImp : Armes {

    #region Static members

    public static readonly Arme Hachette = new(ArmeId.From(Guid.Parse("2B04B9C2-184E-4429-BCE1-D65312394484")),
                                               "Hachette",
                                               new ProfilAttaqueCorpsACorps(
                                                   Caractéristique.Force,
                                                   new ComposantDeDégâts([new GroupeDeDés(1, TypeDeDé.D6)], 0, TypeDeDégâts.Tranchants)),
                                               new ProfilAttaqueDistance(
                                                   Caractéristique.Force,
                                                   new ComposantDeDégâts([new GroupeDeDés(1, TypeDeDé.D6)], 0, TypeDeDégâts.Tranchants),
                                                   new Portée(Distance.From(6), Distance.From(18)))
                                              ,
                                               [
                                                   PropriétéArme.Légère,
                                                   PropriétéArme.Lancer
                                               ]);

    public static readonly Arme MasseDArmes = new(ArmeId.From(Guid.Parse("8D1C8C80-E8A9-4D80-90C0-DEB1D24DA580")),
                                                  "Masse d'armes",
                                                  new ProfilAttaqueCorpsACorps(
                                                      Caractéristique.Force,
                                                      new ComposantDeDégâts([new GroupeDeDés(1, TypeDeDé.D6)], 0, TypeDeDégâts.Contondants))
                                                , null);

    private static readonly Dictionary<ArmeId, Arme> _armes = new([new KeyValuePair<ArmeId, Arme>(Hachette.Id, Hachette), new KeyValuePair<ArmeId, Arme>(MasseDArmes.Id, MasseDArmes)]);

    #endregion

    public Arme GetById(ArmeId id) {
        ArgumentNullException.ThrowIfNull(id);

        return _armes[id];
    }

}