#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

[DebuggerDisplay("{ToString()}")]
public sealed class TypeDeDé : ValueType<TypeDeDé> {

    #region Static members

    private static readonly Dictionary<int, TypeDeDé> _parNombreDeFaces = new();

    public static readonly TypeDeDé D3   = new(3);
    public static readonly TypeDeDé D4   = new(4);
    public static readonly TypeDeDé D6   = new(6);
    public static readonly TypeDeDé D8   = new(8);
    public static readonly TypeDeDé D10  = new(10);
    public static readonly TypeDeDé D12  = new(12);
    public static readonly TypeDeDé D20  = new(20);
    public static readonly TypeDeDé D100 = new(100);

    public static TypeDeDé AvecNombreDeFaces(int nombreDeFaces) {
        if (!_parNombreDeFaces.TryGetValue(nombreDeFaces, out TypeDeDé? type)) { throw new ArgumentException($"Type de dé inconnu : d{nombreDeFaces}"); }

        return type;
    }

    #endregion

    #region Constructors & Destructor

    private TypeDeDé(int nombreDeFaces) {
        if (_parNombreDeFaces.ContainsKey(nombreDeFaces)) { throw new InvalidOperationException($"Un TypeDeDé avec {nombreDeFaces} faces existe déjà."); }

        NombreDeFaces                    = nombreDeFaces;
        _parNombreDeFaces[nombreDeFaces] = this;
    }

    #endregion

    public int NombreDeFaces { get; }

    public override string ToString() {
        return $"d{NombreDeFaces}";
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [NombreDeFaces];
    }

}