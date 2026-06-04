#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

[DebuggerDisplay("{ToString()}")]
public sealed class GroupeDeDés : ValueType<GroupeDeDés> {

    #region Constructors & Destructor

    public GroupeDeDés(int nombre, TypeDeDé typeDeDé) {
        if (nombre <= 0) { throw new ArgumentOutOfRangeException(nameof(nombre)); }

        TypeDeDé = typeDeDé ?? throw new ArgumentNullException(nameof(typeDeDé));
        Nombre   = nombre;
    }

    #endregion

    public int      Nombre   { get; }
    public TypeDeDé TypeDeDé { get; }

    public override string ToString() {
        return $"{Nombre}{TypeDeDé}";
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [Nombre, TypeDeDé];
    }

}