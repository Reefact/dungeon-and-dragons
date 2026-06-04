#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

[DebuggerDisplay("{ToString()}")]
public sealed class PersonnageId : ValueType<PersonnageId> {

    #region Static members

    public static PersonnageId From(Guid value) {
        return new PersonnageId(value);
    }

    #endregion

    #region Fields

    private readonly Guid _value;

    #endregion

    #region Constructors & Destructor

    private PersonnageId(Guid value) {
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