#region Usings declarations

using System.Globalization;
using System.Text;

using DungeonAndDragons.Domain.Model;

#endregion

namespace DungeonAndDragons.CLI.Parsers;

public static class CaractéristiqueParser {

    #region Static members

    private static readonly Dictionary<string, Caractéristique> Map = new() {
        ["for"]   = Caractéristique.Force,
        ["force"] = Caractéristique.Force,

        ["dex"]       = Caractéristique.Dextérité,
        ["dexterite"] = Caractéristique.Dextérité,

        ["con"]          = Caractéristique.Constitution,
        ["constitution"] = Caractéristique.Constitution,

        ["int"]          = Caractéristique.Intelligence,
        ["intelligence"] = Caractéristique.Intelligence,

        ["sag"]     = Caractéristique.Sagesse,
        ["sagesse"] = Caractéristique.Sagesse,

        ["cha"]      = Caractéristique.Charisme,
        ["charisme"] = Caractéristique.Charisme
    };

    public static Caractéristique Parse(string input) {
        string normalized = Normalize(input);

        if (Map.TryGetValue(normalized, out Caractéristique value)) { return value; }

        throw new Exception($"Caractéristique inconnue : {input}");
    }

    private static string Normalize(string input) {
        input = input.ToLowerInvariant();

        input = input
               .Normalize(NormalizationForm.FormD)
               .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
               .Aggregate("", (s, c) => s + c);

        return input;
    }

    #endregion

}