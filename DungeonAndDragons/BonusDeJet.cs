#region Usings declarations

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core;

public sealed class BonusDeJet : ValueType<BonusDeJet> {

    #region Fields

    private readonly IReadOnlyList<SourceDeBonus> _sources;

    #endregion

    #region Constructors & Destructor

    public BonusDeJet(IEnumerable<SourceDeBonus> sources) {
        ArgumentNullException.ThrowIfNull(sources);

        _sources = sources.Select(x => x ?? throw new InvalidOperationException("Une source de bonus ne peut pas être null"))
                          .ToList();
    }

    public BonusDeJet(params SourceDeBonus[] sources) {
        ArgumentNullException.ThrowIfNull(sources);

        _sources = sources.Select(x => x ?? throw new InvalidOperationException("Une source de bonus ne peut pas être null"))
                          .ToList();
    }

    #endregion

    public int GetTotal() {
        return _sources.Sum(x => x.GetBonus());
    }

    public override string ToString() {
        return string.Join(" + ", _sources.Select(x => x.ToString()));
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return _sources.Select(x => (object)x.GetBonus());
    }

}