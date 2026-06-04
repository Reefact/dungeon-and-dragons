#region Usings declarations

using System.Diagnostics;

#endregion

namespace DungeonAndDragons.Domain.Core;

[DebuggerDisplay("{ToString()}")]
public sealed class Classe : SourceDeMaîtrisePourLesJetsDeSauvegarde {

    #region Static members

    public static readonly Classe Barbare     = new("Barbare", [Caractéristique.Force, Caractéristique.Constitution]);
    public static readonly Classe Barde       = new("Barde", [Caractéristique.Dextérité, Caractéristique.Charisme]);
    public static readonly Classe Clerc       = new("Clerc", [Caractéristique.Sagesse, Caractéristique.Charisme]);
    public static readonly Classe Druide      = new("Druide", [Caractéristique.Intelligence, Caractéristique.Sagesse]);
    public static readonly Classe Ensorceleur = new("Ensorceleur", [Caractéristique.Constitution, Caractéristique.Charisme]);
    public static readonly Classe Guerrier    = new("Guerrier", [Caractéristique.Force, Caractéristique.Constitution]);
    public static readonly Classe Magicien    = new("Magicien", [Caractéristique.Intelligence, Caractéristique.Sagesse]);
    public static readonly Classe Moine       = new("Moine", [Caractéristique.Force, Caractéristique.Dextérité]);
    public static readonly Classe Occultiste  = new("Occultiste", [Caractéristique.Sagesse, Caractéristique.Charisme]);
    public static readonly Classe Paladin     = new("Paladin", [Caractéristique.Sagesse, Caractéristique.Charisme]);
    public static readonly Classe Rôdeur      = new("Rôdeur", [Caractéristique.Force, Caractéristique.Dextérité]);
    public static readonly Classe Roublard    = new("Roublard", [Caractéristique.Dextérité, Caractéristique.Intelligence]);

    #endregion

    #region Fields

    private readonly string _toStringName;

    private readonly HashSet<Caractéristique> _caractéristiquesMaitrisées;

    #endregion

    #region Constructors & Destructor

    private Classe(string name, Caractéristique[] caractéristiquesMaitrisées) {
        _toStringName               = name;
        _caractéristiquesMaitrisées = new HashSet<Caractéristique>(caractéristiquesMaitrisées);
    }

    #endregion

    /// <inheritdoc />
    public bool ConfèreLaMaîtriseDeCetteCaractéristiquePourLesJetsDeSauvegarde(Caractéristique caractéristique) {
        return _caractéristiquesMaitrisées.Contains(caractéristique);
    }

    /// <inheritdoc />
    public override string ToString() {
        return _toStringName;
    }

}