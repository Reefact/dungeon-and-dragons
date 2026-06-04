namespace DungeonAndDragons.Domain.Model;

public sealed class JetDeDégâts {

    #region Fields

    private readonly List<ComposantDeDégâts> _composants = new();

    #endregion

    #region Constructors & Destructor

    public JetDeDégâts(IEnumerable<ComposantDeDégâts> composants) {
        _composants = composants.ToList();
    }

    #endregion

    public IReadOnlyList<ComposantDeDégâts> Composants => _composants.AsReadOnly();

    public JetDeDégâts Ajouter(ComposantDeDégâts composant) {
        _composants.Add(composant);

        return this;
    }

    public override string ToString() {
        return string.Join(" + ", _composants);
    }

}