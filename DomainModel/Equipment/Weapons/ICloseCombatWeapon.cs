using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment.Weapons.CloseCombat
{
    public enum CloseCombatWeaponRules
    {
        [Description("A roll of 2-4 is treated as 'stunned'")]
        Concussion,

        [Description("An extra save modifier of -1")]
        CuttingEdge,

        [Description("Opponent may not parry")]
        CannotBeParried,

        [Description("May not use other any other equipment")]
        DifficultToUse,

        [Description("The first purchase is free")]
        FirstOneFree,

        [Description("+2 Strength bonus only on the first turn of every hand-to-hand combat")]
        Heavy,

        [Description("+1 To wound against any Possessed or Undead (a 6 is still required for critical hit). \n Matriarchs and Sister Superiors may carry 2 war-hammers")]
        Holy,

        [Description("Applies to warriors who lost their weapons. Zombies, animals, etc, ignore these rules")]
        LostWeaponsInCombat,

        [Description("When opponent rolls to hit, roll a D6 roll, if the result > then opponent the blow is parried and the attack is discarded")]
        Parry,

        [Description("Can and may attack models not in base contact. Opponent may not strike back(if in close combat, must attack engaged opponent)")]
        Reach,

        [Description("Strike first, even if charged, on the first turn")]
        StrikeFirst,

        [Description("Always strikes last")]
        StrikeLast,

        [Description("May not use other equipment in hand-to-hand combat")]
        TwoHandend,

        [Description("Permanently coated with Black Lotus (On a 6 to hit, automatic wound (roll only to see if a critical hit is scored)")]
        Venomous,

        [Description("One in each hand, +1 attack")]
        Pair,

        [Description("+1 initiative test when climbing")]
        Climb,

        [Description("May not use other equipment in the entire battle")]
        Cumbersome,
    }

    public interface ICloseCombatWeapon : IWeapon, IEquipment
    {
        /// <summary>
        /// Gets the close combat special rules.
        /// </summary>
        /// <value>
        /// The close combat special rules.
        /// </value>
        IReadOnlyCollection<CloseCombatWeaponRules> CloseCombatSpecialRules { get; }

        /// <summary>
        /// Gets the strength modifier.
        /// </summary>
        /// <value>
        /// The strength modifier.
        /// </value>
        int StrengthModifier { get; }

        /// <summary>
        /// Gets to hit modifier.
        /// </summary>
        /// <value>
        /// To hit modifier.
        /// </value>
        int ToHitModifier { get; }
    }
}