#region Usings declarations

using System.Diagnostics;

using Value;

#endregion

namespace DungeonAndDragons.Domain.Core {

    /// <summary>
    ///     Un jet de sauvegarde est un test permettant à un personnage de résister à un effet dangereux, comme un sort, un
    ///     piège ou une condition.<br />
    ///     Il représente sa capacité à éviter, encaisser ou réduire les conséquences de cet effet.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public sealed class JetDeSauvegarde : ValueType<JetDeSauvegarde> {

        #region Constructors & Destructor

        public JetDeSauvegarde(Caractéristique caractéristique, RésultatD20 d20, BonusDeJet bonus) {
            ArgumentNullException.ThrowIfNull(d20);
            ArgumentNullException.ThrowIfNull(bonus);

            Caractéristique = caractéristique;
            D20             = d20;
            Bonus           = bonus;
            Valeur          = d20 + bonus;
        }

        #endregion

        public Caractéristique Caractéristique { get; }
        public RésultatD20     D20             { get; }
        public BonusDeJet      Bonus           { get; }
        public int             Valeur          { get; }

        /// <inheritdoc />
        public override string ToString() {
            return $"Jet de sauvegarde de {Caractéristique}: {Valeur} (d20: {D20}, Bonus: {Bonus.GetTotal()})";
        }

        /// <inheritdoc />
        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality() {
            return [Caractéristique, D20, Bonus];
        }

    }

}