//#region Usings declarations

//using System.Diagnostics;

//using Value;

//#endregion

//namespace DungeonAndDragons.Domain.Core;

//[DebuggerDisplay("{ToString()}")]
//public sealed class Modificateur : ValueType<Modificateur> {

//    private const int _minValue = -5;
//    private const int _maxValue = 5;

//    #region Static members

//    public static Modificateur From(int valeur) {
//        return new Modificateur(valeur);
//    }

//    public static Modificateur From(ValeurDeCaractéristique valeur) {
//        ArgumentNullException.ThrowIfNull(valeur);

//        return new Modificateur((int)Math.Floor((valeur - 10) / 2.0));
//    }

//    #endregion

//    #region Constructors & Destructor

//    private Modificateur(Caractéristique caractéristique, int valeur) {
//        if (valeur is < _minValue or > _maxValue) { throw new ArgumentOutOfRangeException(); }
//        Caractéristique = caractéristique;

//        Valeur = valeur;
//    }

//    #endregion

//    public Caractéristique Caractéristique { get; }

//    public int Valeur { get; }

//    public int Appliquer(int valeur) {
//        return valeur + Valeur;
//    }

//    public override string ToString() {
//        return Valeur >= 0 ? $"+{Valeur}" : Valeur.ToString();
//    }

//    /// <inheritdoc />
//    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
//        return [Valeur];
//    }

//}

