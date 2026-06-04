namespace DungeonAndDragons.Domain.Model;

public sealed class Arme {

    #region Fields

    private readonly IReadOnlyList<ModeAttaque> _modes;

    #endregion

    #region Constructors & Destructor

    public Arme(ArmeId id, string description, IEnumerable<ModeAttaque> modes, IEnumerable<PropriétéArme>? propriétés = null) {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentNullException.ThrowIfNull(modes);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        List<ModeAttaque> list = modes.ToList();

        if (list.Count == 0) {
            throw new InvalidOperationException("Une arme doit avoir au moins un mode d'attaque.");
        }

        _modes = list;

        Id          = id;
        Description = description;
        Propriétés  = new HashSet<PropriétéArme>(propriétés ?? Enumerable.Empty<PropriétéArme>());
    }

    #endregion

    public ArmeId                      Id          { get; }
    public string                      Description { get; }
    public IReadOnlySet<PropriétéArme> Propriétés  { get; }

    public T GetModeAttaque<T>()
        where T : class, ModeAttaque {
        return _modes.OfType<T>().FirstOrDefault()
            ?? throw new InvalidOperationException($"Mode {typeof(T).Name} non disponible.");
    }

    public bool Peut<T>()
        where T : class, ModeAttaque {
        return _modes.OfType<T>().Any();
    }

    public override string ToString() {
        return Description;
    }

}