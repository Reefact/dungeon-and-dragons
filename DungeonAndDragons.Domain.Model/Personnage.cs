#region Usings declarations

using System.Diagnostics;

#endregion

namespace DungeonAndDragons.Domain.Model;

[DebuggerDisplay("{ToString()}")]
public sealed class Personnage {

    #region Fields

    private readonly string           _nom;
    private readonly Niveau           _niveau;
    private readonly Classe           _classe;
    private readonly Caractéristiques _caractéristiques;

    #endregion

    #region Constructors & Destructor

    public Personnage(PersonnageId id, string nom, Classe classe, Niveau niveau, Caractéristiques caractéristiques, IEnumerable<ArmeId> armes) {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(nom);
        ArgumentNullException.ThrowIfNull(classe);
        ArgumentNullException.ThrowIfNull(niveau);
        ArgumentNullException.ThrowIfNull(caractéristiques);
        ArgumentNullException.ThrowIfNull(armes);

        Id                = id;
        _armes            = armes.ToHashSet();
        _nom              = nom;
        _classe           = classe;
        _niveau           = niveau;
        _caractéristiques = caractéristiques;
    }

    public Personnage(PersonnageId id, string nom, Classe classe, Niveau niveau, Caractéristiques caractéristiques) {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(nom);
        ArgumentNullException.ThrowIfNull(classe);
        ArgumentNullException.ThrowIfNull(niveau);
        ArgumentNullException.ThrowIfNull(caractéristiques);
        Id                = id;
        _armes            = new HashSet<ArmeId>();
        _nom              = nom;
        _classe           = classe;
        _niveau           = niveau;
        _caractéristiques = caractéristiques;
    }

    #endregion

    public  PersonnageId    Id     { get; }
    private HashSet<ArmeId> _armes { get; }

    public ValeurDeCaractéristique GetForceIntrinsèque() {
        return _caractéristiques.Force;
    }

    public ValeurDeCaractéristique GetForceActuelle() {
        return _caractéristiques.Force;
    }

    public ValeurDeCaractéristique GetDextéritéIntrinsèque() {
        return _caractéristiques.Dextérité;
    }

    public ValeurDeCaractéristique GetDextéritéActuelle() {
        return _caractéristiques.Dextérité;
    }

    public ValeurDeCaractéristique GetConstitutionIntrinsèque() {
        return _caractéristiques.Constitution;
    }

    public ValeurDeCaractéristique GetConstitutionActuelle() {
        return _caractéristiques.Constitution;
    }

    public ValeurDeCaractéristique GetIntelligenceIntrinsèque() {
        return _caractéristiques.Intelligence;
    }

    public ValeurDeCaractéristique GetIntelligenceActuelle() {
        return _caractéristiques.Intelligence;
    }

    public ValeurDeCaractéristique GetSagesseIntrinsèque() {
        return _caractéristiques.Sagesse;
    }

    public ValeurDeCaractéristique GetSagesseActuelle() {
        return _caractéristiques.Sagesse;
    }

    public ValeurDeCaractéristique GetCharismeIntrinsèque() {
        return _caractéristiques.Charisme;
    }

    public ValeurDeCaractéristique GetCharismeActuel() {
        return _caractéristiques.Charisme;
    }

    public ValeurDeCaractéristique GetValeurActuelle(Caractéristique caractéristique) {
        return caractéristique switch {
            Caractéristique.Force        => GetForceActuelle(),
            Caractéristique.Dextérité    => GetDextéritéActuelle(),
            Caractéristique.Constitution => GetConstitutionActuelle(),
            Caractéristique.Intelligence => GetIntelligenceActuelle(),
            Caractéristique.Sagesse      => GetSagesseActuelle(),
            Caractéristique.Charisme     => GetCharismeActuel(),
            _                            => throw new ArgumentOutOfRangeException(nameof(caractéristique), caractéristique, null)
        };
    }

    public MaîtriseDeCaractéristique GetMaîtrise(Caractéristique caractéristique) {
        bool                      maîtriseLaCaractéristique = _classe.ConfèreLaMaîtriseDeCetteCaractéristiquePourLesJetsDeSauvegarde(caractéristique);
        MaîtriseDeCaractéristique bonusDeMaîtrise           = maîtriseLaCaractéristique ? MaîtriseDeCaractéristique.Maîtrisée(caractéristique, _niveau) : MaîtriseDeCaractéristique.NonMaîtrisée(caractéristique);

        return bonusDeMaîtrise;
    }

    /// <inheritdoc />
    public override string ToString() {
        return _nom;
    }

    public bool Maitrise(Caractéristique caractéristique) {
        return _classe.ConfèreLaMaîtriseDeCetteCaractéristiquePourLesJetsDeSauvegarde(caractéristique);
    }

    public bool NeMaitrisePas(Caractéristique caractéristique) {
        return !Maitrise(caractéristique);
    }

    public bool NePossèdePas(ArmeId armeId) {
        return false;
    }

    public bool PeutAtteindreSaCible(Arme arme, Distance distance) {
        ArgumentNullException.ThrowIfNull(arme);
        ArgumentNullException.ThrowIfNull(distance);

        AttaqueDistance attaqueDistance = arme.GetModeAttaque<AttaqueDistance>();

        return attaqueDistance.Portée.EstAPortée(distance);
    }

    public bool NePeutPasAtteindreSaCible(Arme arme, Distance distance) {
        return !PeutAtteindreSaCible(arme, distance);
    }

}