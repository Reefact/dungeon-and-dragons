#region Usings declarations

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

public sealed class Désavantage : ValueType<Avantage> {

    #region Constructors & Destructor

    public Désavantage(RésultatD20 premierLancé, RésultatD20 secondLancé) {
        ArgumentNullException.ThrowIfNull(premierLancé);
        ArgumentNullException.ThrowIfNull(secondLancé);

        PremierLancé = premierLancé;
        SecondLancé  = secondLancé;
        Valeur       = RésultatD20.GetMin(premierLancé, secondLancé);
    }

    #endregion

    public RésultatD20 PremierLancé { get; }
    public RésultatD20 SecondLancé  { get; }

    public RésultatD20 Valeur { get; }

    /// <inheritdoc />
    public override string ToString() {
        return $"({PremierLancé};{SecondLancé})";
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [PremierLancé, SecondLancé];
    }

}