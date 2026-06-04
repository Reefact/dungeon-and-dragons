#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

[DebuggerDisplay("{ToString()}")]
public sealed class ArmeId : ValueType<ArmeId> {

    #region Static members

    public static ArmeId From(Guid value) {
        return new ArmeId(value);
    }

    #endregion

    #region Fields

    private readonly Guid _value;

    #endregion

    #region Constructors & Destructor

    private ArmeId(Guid value) {
        if (value == Guid.Empty) { throw new ArgumentException("Un identifiant d'arme ne peut pas être vide.", nameof(value)); }

        _value = value;
    }

    #endregion

    public Guid Dehydrate() {
        return _value;
    }

    public override string ToString() {
        return _value.ToString();
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [_value];
    }

}