#region Usings declarations

using DungeonAndDragons.CLI.Commands;

using Spectre.Console.Cli;

#endregion

CommandApp app = new();

app.Configure(config => {
    config.AddCommand<JetDeSauvegardeCommand>("js")
          .WithDescription("Jet de sauvegarde")
          .WithAlias("jet-sauvegarde")
          .WithAlias("jet-de-sauvegarde");
    config.AddCommand<LancerArmeCommand>("ja")
          .WithDescription("Jet d'attaque")
          .WithAlias("jet-attaque")
          .WithAlias("jet-d-attaque");
});

return app.Run(args);