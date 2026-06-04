namespace DungeonAndDragons.Domain.Model;

public abstract class ProfilAttaqueArme {

    #region Constructors & Destructor

    public ProfilAttaqueArme(Caractéristique caractéristiqueUtilisée, ComposantDeDégâts dégatsDeBase) {
        ArgumentNullException.ThrowIfNull(dégatsDeBase);

        CaractéristiqueUtilisée = caractéristiqueUtilisée;
        DégatsDeBase            = dégatsDeBase;
    }

    #endregion

    //  public TypeAttaque       TypeAttaque             { get; }
    public Caractéristique   CaractéristiqueUtilisée { get; }
    public ComposantDeDégâts DégatsDeBase            { get; }

}

public sealed class ProfilAttaqueCorpsACorps : ProfilAttaqueArme {

    #region Constructors & Destructor

    public ProfilAttaqueCorpsACorps(Caractéristique   caractéristiqueUtilisée,
                                    ComposantDeDégâts dégâts)
        : base(caractéristiqueUtilisée, dégâts) { }

    #endregion

}

public sealed class ProfilAttaqueDistance : ProfilAttaqueArme {

    #region Constructors & Destructor

    public ProfilAttaqueDistance(Caractéristique   caractéristiqueUtilisée,
                                 ComposantDeDégâts dégâts,
                                 Portée            portée)
        : base(caractéristiqueUtilisée, dégâts) {
        ArgumentNullException.ThrowIfNull(portée);
        Portée = portée;
    }

    #endregion

    public Portée Portée { get; }

}