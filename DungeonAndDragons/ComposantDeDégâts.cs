#region Usings declarations

using System.Collections.ObjectModel;

#endregion

namespace DungeonAndDragons.Domain.Core;

public sealed class ComposantDeDégâts {

    #region Constructors & Destructor

    public ComposantDeDégâts(IEnumerable<GroupeDeDés> groupesDeDés,
                             int                      bonusFixe,
                             TypeDeDégâts             typeDeDégâts) {
        ArgumentNullException.ThrowIfNull(groupesDeDés);

        ReadOnlyCollection<GroupeDeDés> expressions = groupesDeDés.ToList().AsReadOnly();

        if (expressions.Count == 0 && bonusFixe == 0) {
            throw new ArgumentException("Un composant de dégâts doit contenir au moins des dés ou un bonus fixe.");
        }

        GroupesDeDés = expressions;
        BonusFixe    = bonusFixe;
        TypeDeDégâts = typeDeDégâts;
    }

    #endregion

    public IReadOnlyList<GroupeDeDés> GroupesDeDés { get; }
    public TypeDeDégâts               TypeDeDégâts { get; }
    public int                        BonusFixe    { get; }

    public int LancerDégâts(Joueur joueur) {
        ArgumentNullException.ThrowIfNull(joueur);
        int total = 0;

        foreach (GroupeDeDés groupe in GroupesDeDés) {
            for (int i = 0; i < groupe.Nombre; i++) {
                total += joueur.Lancer(groupe.TypeDeDé);
            }
        }

        return total;
    }

    public override string ToString() {
        List<string> morceaux = new();

        morceaux.AddRange(GroupesDeDés.Select(x => x.ToString()));

        if (BonusFixe > 0) {
            morceaux.Add($"+ {BonusFixe}");
        } else if (BonusFixe < 0) {
            morceaux.Add($"- {Math.Abs(BonusFixe)}");
        }

        return $"{string.Join(" ", morceaux)} ({TypeDeDégâts})";
    }

}