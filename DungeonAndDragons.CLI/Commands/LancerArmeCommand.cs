#region Usings declarations

using DungeonAndDragons.CLI.__tmp;
using DungeonAndDragons.Domain.Core;
using DungeonAndDragons.Domain.UseCases;

using Spectre.Console.Cli;

#endregion

namespace DungeonAndDragons.CLI.Commands {

    public sealed class LancerArmeCommand : Command<LancerArmeCommand.Settings> {

        /// <inheritdoc />
        protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken) {
            //Caractéristique caractéristique = CaractéristiqueParser.Parse(settings.Caractéristique);
            //AnsiConsole.MarkupLine($"[bold]Jet de sauvegarde de {ToFrench(caractéristique)}[/]");

            Personnages    personnages  = new PersonnagesImp();
            Armes          armes        = new ArmesImp();
            Joueur         joueur       = new JoueurImp();
            LancerArme     lancerArme   = new(personnages, armes, joueur);
            PersonnageId   personnageId = PersonnageId.From(Guid.Parse("DDF2CA5B-327E-40DC-BFCA-D9769F7B66F9"));
            ArmeId         armeId       = ArmeId.From(Guid.Parse("2B04B9C2-184E-4429-BCE1-D65312394484")); // hachette
            Distance       distance     = Distance.From(settings.Distance);
            LancerArmeArgs args         = new(personnageId, armeId, distance);
            lancerArme.Exécuter(args);

            //AnsiConsole.MarkupLine($"=> {jetAttaque}");
            //AnsiConsole.MarkupLine($"Résultat : [bold]{jetAttaque.Valeur}[/]");

            return 0;
        }

        #region Nested types

        public class Settings : CommandSettings {

            [CommandOption("-d|--distance")] public int Distance { get; set; }

        }

        #endregion

    }

}