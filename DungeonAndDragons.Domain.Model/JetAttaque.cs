#region Usings declarations

using Value;

#endregion

namespace DungeonAndDragons.Domain.Model;

public sealed class JetAttaque : ValueType<JetAttaque> {

    #region Constructors & Destructor

    public JetAttaque(Caractéristique caractéristique, RésultatD20 d20, BonusDeJet bonus) {
        ArgumentNullException.ThrowIfNull(d20);
        ArgumentNullException.ThrowIfNull(bonus);

        Caractéristique = caractéristique;
        D20             = d20;
        Bonus           = bonus;

        Valeur = d20 + bonus;
    }

    #endregion

    public Caractéristique Caractéristique { get; }
    public RésultatD20     D20             { get; }
    public BonusDeJet      Bonus           { get; }
    public int             Valeur          { get; }

    public bool EstSuccèsCritique => D20.EstLaValeurMaximum();
    public bool EstEchecCritique  => D20.EstLaValeurMinimum();

    public override string ToString() {
        return $"Jet d'attaque ({Caractéristique}) : {Valeur} (d20: {D20}, bonus: {Bonus.GetTotal()})";
    }

    protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
        return [Caractéristique, D20, Bonus.GetTotal()];
    }

}

public interface SourceDeBonus {

    int GetBonus();

}