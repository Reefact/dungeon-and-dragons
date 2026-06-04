#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

[DebuggerDisplay("{ToString()}")]
public sealed class Portée : ValueType<Portée> {

    #region Constructors & Destructor

    public Portée(Distance normale, Distance longue) {
        ArgumentNullException.ThrowIfNull(normale);
        ArgumentNullException.ThrowIfNull(longue);

        Normale = normale;
        Longue  = longue;
    }

    #endregion

    public Distance Normale { get; }
    public Distance Longue  { get; }

    public ZoneDePortée Evaluer(Distance distance) {
        if (distance.CompareTo(Normale) <= 0) { return ZoneDePortée.Normale; }
        if (distance.CompareTo(Longue)  <= 0) { return ZoneDePortée.Longue; }

        return ZoneDePortée.HorsPortée;
    }

    public bool EstHorsPortée(Distance distance) {
        ArgumentNullException.ThrowIfNull(distance);

        return Evaluer(distance) == ZoneDePortée.HorsPortée;
    }

    public bool EstAPortée(Distance distance) {
        ArgumentNullException.ThrowIfNull(distance);

        return Evaluer(distance) != ZoneDePortée.HorsPortée;
    }

    /// <inheritdoc />
    public override string ToString() {
        return $"[0;{Normale}] / ]{Normale};{Longue}]";
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [Normale, Longue];
    }

}

//[DebuggerDisplay("{ToString()}")]
//public sealed class EvaluationPortée: ValueType<EvaluationPortée>
//{
//    public bool Valide       { get; }
//    public bool Désavantage { get; }

//    private EvaluationPortée(bool valide, bool désavantage)
//    {
//        Valide      = valide;
//        Désavantage = désavantage;
//    }

//    public static      EvaluationPortée    HorsPortée()                          => new(false, false);
//    public static      EvaluationPortée    Normale()                             => new(true, false);
//    public static      EvaluationPortée    Longue()                              => new(true, true);

//    /// <inheritdoc />
//    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
//        return [Valide, Désavantage];
//    }

//    /// <inheritdoc />
//    public override string ToString() {
//        return $"";
//    }

//}