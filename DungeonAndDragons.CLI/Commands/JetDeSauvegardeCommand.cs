#region Usings declarations

using DungeonAndDragons.CLI.__tmp;
using DungeonAndDragons.CLI.Parsers;
using DungeonAndDragons.Domain.Model;
using DungeonAndDragons.Domain.UseCases;

using Spectre.Console;
using Spectre.Console.Cli;

#endregion

namespace DungeonAndDragons.CLI.Commands;

public class JetDeSauvegardeCommand : Command<JetDeSauvegardeCommand.Settings> {

    #region Static members

    private static string FormatMod(int value) {
        return value >= 0 ? $"+{value}" : value.ToString();
    }

    private static string ToFrench(Caractéristique c) {
        return c switch {
            Caractéristique.Force        => "Force",
            Caractéristique.Dextérité    => "Dextérité",
            Caractéristique.Constitution => "Constitution",
            Caractéristique.Intelligence => "Intelligence",
            Caractéristique.Sagesse      => "Sagesse",
            Caractéristique.Charisme     => "Charisme",
            _                            => c.ToString()
        };
    }

    #endregion

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken) {
        Caractéristique caractéristique = CaractéristiqueParser.Parse(settings.Caractéristique);
        AnsiConsole.MarkupLine($"[bold]Jet de sauvegarde de {ToFrench(caractéristique)}[/]");

        Personnages                  personnages              = new PersonnagesImp();
        Joueur                       joueur                   = new JoueurImp();
        EffectuerJetDeSauvegarde     effectuerJetDeSauvegarde = new(personnages, joueur);
        PersonnageId                 personnageId             = PersonnageId.From(Guid.Parse("DDF2CA5B-327E-40DC-BFCA-D9769F7B66F9"));
        EffectuerJetDeSauvegardeArgs args                     = new(personnageId, caractéristique);
        JetDeSauvegarde              jetDeSauvegarde          = effectuerJetDeSauvegarde.Execute(args);

        AnsiConsole.MarkupLine($"=> {jetDeSauvegarde}");
        AnsiConsole.MarkupLine($"Résultat : [bold]{jetDeSauvegarde.Valeur}[/]");

        return 0;
    }

    #region Nested types

    public class Settings : CommandSettings {

        [CommandArgument(0, "<caractéristique>")]
        public string Caractéristique { get; set; } = default!;

        [CommandOption("-a|--avantage")] public bool Avantage { get; set; }

        [CommandOption("-d|--desavantage|--désavantage")]
        public bool Desavantage { get;                      set; }
        [CommandOption("--trace")] public bool Trace { get; set; }

    }

    #endregion

}