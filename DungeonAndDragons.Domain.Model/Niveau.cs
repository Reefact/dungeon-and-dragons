#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

[DebuggerDisplay("{ToString()}")]
public sealed class Niveau : ValueType<Niveau> {

    #region Static members

    public static Niveau From(int value) {
        if (value is < 1 or > 20) { throw new ArgumentOutOfRangeException("Le niveau d'un personnage ne peut dépasser 20."); }

        return new Niveau(value);
    }

    #endregion

    public static implicit operator int(Niveau niveau) {
        return niveau._value;
    }

    #region Fields

    private readonly int _value;

    #endregion

    #region Constructors & Destructor

    private Niveau(int value) {
        _value = value;
    }

    #endregion

    /// <inheritdoc />
    public override string ToString() {
        return _value.ToString();
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [_value];
    }

}