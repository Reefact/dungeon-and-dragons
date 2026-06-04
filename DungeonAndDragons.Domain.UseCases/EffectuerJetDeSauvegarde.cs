#region Usings declarations

using DungeonAndDragons.Domain.Core;

#endregion

namespace DungeonAndDragons.Domain.UseCases;

public sealed class EffectuerJetDeSauvegarde {

    #region Fields

    private readonly Personnages _personnages;
    private readonly Joueur      _joueur;

    #endregion

    #region Constructors & Destructor

    public EffectuerJetDeSauvegarde(Personnages personnages, Joueur joueur) {
        ArgumentNullException.ThrowIfNull(personnages);
        ArgumentNullException.ThrowIfNull(joueur);

        _personnages = personnages;
        _joueur      = joueur;
    }

    #endregion

    public JetDeSauvegarde Execute(EffectuerJetDeSauvegardeArgs args) {
        ArgumentNullException.ThrowIfNull(args);

        Personnage                personnage              = _personnages.GetById(args.PersonnageId);
        ValeurDeCaractéristique   valeurDeCaractéristique = personnage.GetValeurActuelle(args.Caractéristique);
        MaîtriseDeCaractéristique maîtrise                = personnage.GetMaîtrise(args.Caractéristique);
        RésultatD20               d20                     = _joueur.LancerD20();
        BonusDeJet                bonus                   = new(maîtrise, valeurDeCaractéristique);
        JetDeSauvegarde           jetDeSauvegarde         = new(args.Caractéristique, d20, bonus);

        return jetDeSauvegarde;
    }

}