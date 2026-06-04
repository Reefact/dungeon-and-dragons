#region Usings declarations

using DungeonAndDragons.Domain.Model;

#endregion

namespace DungeonAndDragons.CLI.__tmp;

public sealed class MaîtreDuJeuImp : MaîtreDuJeu {

    /// <inheritdoc />
    public bool EstTouché(JetAttaque jetAttaque) {
        ArgumentNullException.ThrowIfNull(jetAttaque);

        throw new NotImplementedException();
    }

}