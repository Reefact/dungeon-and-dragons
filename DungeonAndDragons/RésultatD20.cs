#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

/// <summary>
///     Représente le résultat du jeté d'un d20.
/// </summary>
[DebuggerDisplay("{ToString()")]
public sealed class RésultatD20 : ValueType<RésultatD20> {

    private const int _maxValue = 20;
    private const int _minValue = 1;

    #region Static members

    public static RésultatD20 FromInt32(int value) {
        if (value is < _minValue or > _maxValue) { throw new ArgumentException(); }

        return new RésultatD20(value);
    }

    public static RésultatD20 GetMax(RésultatD20 résultat1, RésultatD20 résultat2) {
        return résultat1 >= résultat2 ? résultat1 : résultat2;
    }

    public static RésultatD20 GetMin(RésultatD20 résultat1, RésultatD20 résultat2) {
        return résultat1 <= résultat2 ? résultat1 : résultat2;
    }

    #endregion

    public static bool operator >=(RésultatD20 left, RésultatD20 right) {
        return left._value >= right._value;
    }

    public static bool operator <=(RésultatD20 left, RésultatD20 right) {
        return left._value <= right._value;
    }

    public static bool operator >(RésultatD20 left, RésultatD20 right) {
        return left._value > right._value;
    }

    public static bool operator <(RésultatD20 left, RésultatD20 right) {
        return left._value < right._value;
    }

    public static int operator +(RésultatD20 d20, BonusDeJet bonusJet) {
        ArgumentNullException.ThrowIfNull(d20);
        ArgumentNullException.ThrowIfNull(bonusJet);

        return d20._value + bonusJet.GetTotal();
    }

    #region Fields

    private readonly int _value;

    #endregion

    #region Constructors & Destructor

    private RésultatD20(int value) {
        _value = value;
    }

    #endregion

    public bool EstLaValeurMaximum() {
        return _value == _maxValue;
    }

    public bool EstLaValeurMinimum() {
        return _value == _minValue;
    }

    /// <inheritdoc />
    public override string ToString() {
        return _value.ToString();
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [_value];
    }

}