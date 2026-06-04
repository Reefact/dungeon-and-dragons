#region Usings declarations

using DungeonAndDragons.Domain.Core;

#endregion

namespace DungeonAndDragons.Domain.UseCases;

public sealed class LancerArme {

    #region Static members

    private static JetAttaque CalculerJetAttaque(Joueur joueur, Personnage personnage, Arme arme) {
        AttaqueDistance           attaqueDistance           = arme.GetModeAttaque<AttaqueDistance>();
        Caractéristique           caractéristiqueUtilisée   = attaqueDistance.CaractéristiqueUtilisée;
        MaîtriseDeCaractéristique maîtriseDeCaractéristique = personnage.GetMaîtrise(caractéristiqueUtilisée);
        ValeurDeCaractéristique   valeurDeCaractéristique   = personnage.GetValeurActuelle(caractéristiqueUtilisée);
        BonusDeJet                bonus                     = new(maîtriseDeCaractéristique, valeurDeCaractéristique);
        RésultatD20               d20                       = joueur.LancerD20();
        JetAttaque                jetAttaque                = new(caractéristiqueUtilisée, d20, bonus);

        return jetAttaque;
    }

    #endregion

    #region Fields

    private readonly Personnages _personnages;
    private readonly Armes       _armes;
    private readonly Joueur      _joueur;
    private readonly MaîtreDuJeu _maîtreDuJeu;

    #endregion

    #region Constructors & Destructor

    public LancerArme(Personnages personnages, Armes armes, Joueur joueur, MaîtreDuJeu maîtreDuJeu) {
        ArgumentNullException.ThrowIfNull(personnages);
        ArgumentNullException.ThrowIfNull(armes);
        ArgumentNullException.ThrowIfNull(joueur);

        _personnages = personnages;
        _armes       = armes;
        _joueur      = joueur;
        _maîtreDuJeu = maîtreDuJeu;
    }

    #endregion

    public void Exécuter(LancerArmeArgs args) {
        ArgumentNullException.ThrowIfNull(args);

        Personnage personnage = _personnages.GetById(args.PersonnageId);
        if (personnage.NePossèdePas(args.ArmeId)) { throw new InvalidOperationException(); }

        Arme arme = _armes.GetById(args.ArmeId);
        if (personnage.NePeutPasAtteindreSaCible(arme, args.DistanceDeLaCible)) { throw new InvalidOperationException(); }

        JetAttaque jetAttaque = CalculerJetAttaque(_joueur, personnage, arme);

        bool estTouché = _maîtreDuJeu.EstTouché(jetAttaque);
        if (estTouché) {
            AttaqueDistance attaqueDistance = arme.GetModeAttaque<AttaqueDistance>();
            personnage.Attaque<AttaqueDistance>()
            int             dégâts          = attaqueDistance.CalculerDégâts(_joueur, personnage, args.DistanceDeLaCible);

            // ...
        }
    }

}