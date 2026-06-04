#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

[DebuggerDisplay("{ToString()}")]
public sealed class MaîtriseDeCaractéristique : ValueType<MaîtriseDeCaractéristique>, SourceDeBonus {

    #region Static members

    public static MaîtriseDeCaractéristique NonMaîtrisée(Caractéristique caractéristique) {
        return new MaîtriseDeCaractéristique(caractéristique, 0);
    }

    public static MaîtriseDeCaractéristique Maîtrisée(Caractéristique caractéristique, Niveau niveau) {
        ArgumentNullException.ThrowIfNull(niveau);

        return (int)niveau switch {
            <= 4  => new MaîtriseDeCaractéristique(caractéristique, 2),
            <= 8  => new MaîtriseDeCaractéristique(caractéristique, 3),
            <= 12 => new MaîtriseDeCaractéristique(caractéristique, 4),
            <= 16 => new MaîtriseDeCaractéristique(caractéristique, 5),
            <= 20 => new MaîtriseDeCaractéristique(caractéristique, 6),
            _     => throw new ArgumentOutOfRangeException("Pas possible pour un perso")
        };
    }

    #endregion

    #region Constructors & Destructor

    private MaîtriseDeCaractéristique(Caractéristique caractéristique, int bonus) {
        Caractéristique = caractéristique;
        Valeur          = bonus;
    }

    #endregion

    public Caractéristique Caractéristique { get; }
    public int             Valeur          { get; }

    /// <inheritdoc />
    public override string ToString() {
        return $"{Caractéristique}: +{Valeur}";
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [Caractéristique, Valeur];
    }

    /// <inheritdoc />
    int SourceDeBonus.GetBonus() {
        return Valeur;
    }

    ////[RehydrationMethod()]
    //public static MaîtriseDeCaractéristique From(Caractéristique caractéristique, int bonus) {
    //    if (bonus is < 0 or > 6) { throw new ArgumentOutOfRangeException(""); }

    //    return new MaîtriseDeCaractéristique(caractéristique, bonus);
    //}

}