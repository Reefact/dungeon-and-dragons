#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

[DebuggerDisplay("{ToString()}")]
public sealed class Caractéristiques : ValueType<Caractéristiques> {

    #region Constructors & Destructor

    /// <inheritdoc />
    public Caractéristiques(ValeurDeCaractéristique force, ValeurDeCaractéristique dextérité, ValeurDeCaractéristique constitution, ValeurDeCaractéristique intelligence, ValeurDeCaractéristique sagesse, ValeurDeCaractéristique charisme) {
        ArgumentNullException.ThrowIfNull(force);
        ArgumentNullException.ThrowIfNull(dextérité);
        ArgumentNullException.ThrowIfNull(constitution);
        ArgumentNullException.ThrowIfNull(intelligence);
        ArgumentNullException.ThrowIfNull(sagesse);
        ArgumentNullException.ThrowIfNull(charisme);

        Force        = force;
        Dextérité    = dextérité;
        Constitution = constitution;
        Intelligence = intelligence;
        Sagesse      = sagesse;
        Charisme     = charisme;
    }

    #endregion

    public ValeurDeCaractéristique Force        { get; }
    public ValeurDeCaractéristique Dextérité    { get; }
    public ValeurDeCaractéristique Constitution { get; }
    public ValeurDeCaractéristique Intelligence { get; }
    public ValeurDeCaractéristique Sagesse      { get; }
    public ValeurDeCaractéristique Charisme     { get; }

    /// <inheritdoc />
    public override string ToString() {
        return $"Force={Force}, Dextérité={Dextérité}, Constitution={Constitution}, Intelligence={Intelligence}, Sagesse={Sagesse}, Charisme={Charisme}";
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [Force, Dextérité, Constitution, Intelligence, Sagesse, Charisme];
    }

}