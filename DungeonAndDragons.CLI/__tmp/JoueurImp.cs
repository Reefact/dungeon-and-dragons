#region Usings declarations

using DungeonAndDragons.Domain.Core;

using Spectre.Console;

#endregion

namespace DungeonAndDragons.CLI.__tmp;

public sealed class JoueurImp : Joueur {

    /// <inheritdoc />
    public RésultatD20 LancerD20() {
        int         input       = AnsiConsole.Ask<int>("[bold yellow]> Lance un d20 :[/]");
        RésultatD20 résultatD20 = RésultatD20.FromInt32(input);

        return résultatD20;
    }

}