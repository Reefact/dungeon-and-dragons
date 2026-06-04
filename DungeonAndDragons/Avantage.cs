#region Usings declarations

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

public sealed class Avantage : ValueType<Avantage> {

    #region Constructors & Destructor

    public Avantage(RésultatD20 premierLancé, RésultatD20 secondLancé) {
        ArgumentNullException.ThrowIfNull(premierLancé);
        ArgumentNullException.ThrowIfNull(secondLancé);

        PremierLancé = premierLancé;
        SecondLancé  = secondLancé;
        Valeur       = RésultatD20.GetMax(premierLancé, secondLancé);
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