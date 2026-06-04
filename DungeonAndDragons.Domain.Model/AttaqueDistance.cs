namespace DungeonAndDragons.Domain.Model;

public sealed class AttaqueDistance : ModeAttaque {

    #region Constructors & Destructor

    public AttaqueDistance(Caractéristique caractéristique, ComposantDeDégâts dégâts, Portée portée) {
        CaractéristiqueUtilisée = caractéristique;
        Dégâts                  = dégâts;
        Portée                  = portée;
    }

    #endregion

    public Caractéristique   CaractéristiqueUtilisée { get; }
    public ComposantDeDégâts Dégâts                  { get; }
    public Portée            Portée                  { get; }

    public int CalculerDégâts(Joueur joueur, Personnage personnage, Distance distance) {
        int dégâts = Dégâts.LancerDégâts(joueur);

        // 👉 ici tu peux ajouter :
        // - bonus de caractéristique
        // - bonus magique
        // - etc.

        return dégâts;
    }

}