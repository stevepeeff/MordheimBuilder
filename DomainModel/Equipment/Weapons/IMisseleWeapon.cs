using System.Collections.Generic;
using System.ComponentModel;

namespace DomainModel.Equipment.Weapons
{
    public enum MisseleWeaponRules
    {
        [Description("+1 Bonus on to hit roles")]
        Accuracy,

        [Description("May not move and fire other than pivot")]
        MoveOrFire,

        [Description("On a 6 to hit, automatic wound (never causes a critical hit)")]
        Poison,

        [Description("May remain hidden if victim fails Initiate test")]
        Stealthy,

        [Description("No penalties for moving or range")]
        ThrownWeapon,

        [Description("May only be used once during per battle")]
        FireOnce,

        [Description("May fire twice at half range with a -1 to hit")]
        FireTwiceAtHalfRange,

        [Description("May fire every Turn")]
        Brace,

        FireEveryOtherTurn,

        [Description("Always shoot first in close combat with a -2 To hit penalty")]
        ShootOnceInMelee,

        FireTwice,

        [Description("Take a whole turn to reload")]
        PrepareShot,

        HandToHand,
        PickTarget
    }

    public interface IMisseleWeapon : IWeapon, IEquipment
    {
        int Strength { get; }

        IReadOnlyCollection<MisseleWeaponRules> MisseleWeaponSpecialRules { get; }

        int Range { get; }
    }
}