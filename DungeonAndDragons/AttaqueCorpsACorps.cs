namespace DungeonAndDragons.Domain.Core;

public sealed class AttaqueCorpsACorps : ModeAttaque {

    #region Constructors & Destructor

    public AttaqueCorpsACorps(Caractéristique caractéristique, ComposantDeDégâts dégâts) {
        CaractéristiqueUtilisée = caractéristique;
        Dégâts                  = dégâts;
    }

    #endregion

    public Caractéristique   CaractéristiqueUtilisée { get; }
    public ComposantDeDégâts Dégâts                  { get; }

}