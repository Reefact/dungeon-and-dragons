#region Usings declarations

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

public sealed class ValeurDeCaractéristique : ValueType<ValeurDeCaractéristique>, SourceDeBonus {

    #region Static members

    public static ValeurDeCaractéristique From(Caractéristique caractéristique, int valeur) {
        if (valeur is < 1 or > 30) { throw new ArgumentOutOfRangeException(); }

        return new ValeurDeCaractéristique(caractéristique, valeur);
    }

    #endregion

    #region Constructors & Destructor

    private ValeurDeCaractéristique(Caractéristique caractéristique, int valeur) {
        Caractéristique = caractéristique;
        Valeur          = valeur;
        Modificateur    = (int)Math.Floor((valeur - 10) / 2.0);
    }

    #endregion

    public Caractéristique Caractéristique { get; }
    public int             Valeur          { get; }
    public int             Modificateur    { get; }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [Caractéristique, Valeur];
    }

    /// <inheritdoc />
    int SourceDeBonus.GetBonus() {
        return Modificateur;
    }

}