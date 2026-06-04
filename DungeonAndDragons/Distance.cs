#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

[DebuggerDisplay("{ToString()}")]
public sealed class Distance : ValueType<Distance>, IComparable<Distance>, IComparable {

    #region Static members

    public static Distance From(int mètres) {
        ArgumentOutOfRangeException.ThrowIfNegative(mètres);

        return new Distance(mètres);
    }

    #endregion

    public static bool operator <(Distance? left, Distance? right) {
        return Comparer<Distance>.Default.Compare(left, right) < 0;
    }

    public static bool operator >(Distance? left, Distance? right) {
        return Comparer<Distance>.Default.Compare(left, right) > 0;
    }

    public static bool operator <=(Distance? left, Distance? right) {
        return Comparer<Distance>.Default.Compare(left, right) <= 0;
    }

    public static bool operator >=(Distance? left, Distance? right) {
        return Comparer<Distance>.Default.Compare(left, right) >= 0;
    }

    #region Fields

    private readonly int _mètres;

    #endregion

    #region Constructors & Destructor

    private Distance(int mètres) {
        _mètres = mètres;
    }

    #endregion

    /// <inheritdoc />
    public override string ToString() {
        return $"{_mètres}m";
    }

    /// <inheritdoc />
    public int CompareTo(Distance? other) {
        if (ReferenceEquals(this, other)) { return 0; }
        if (other is null) { return 1; }

        return _mètres.CompareTo(other._mètres);
    }

    /// <inheritdoc />
    public int CompareTo(object? obj) {
        if (obj is null) { return 1; }
        if (ReferenceEquals(this, obj)) { return 0; }

        return obj is Distance other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Distance)}");
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [_mètres];
    }

}