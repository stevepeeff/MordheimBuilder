using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment
{
    public static class EquipmentTools
    {
        internal const int MAXIMUM_NUMBER_OF_WEAPONS = 2;

        public static int CountNumberOf<T>(this IReadOnlyCollection<IEquipment> list)
        {
            int numberOfT = 0;
            foreach (var item in list)
            {
                if (item is T)
                {
                    numberOfT++;
                }
            }
            return numberOfT;
        }

        //private static T Get<T>(this IReadOnlyCollection<IEquipment> list) where : T is IEquipment
        //{
        //    int numberOfT = 0;
        //    foreach (var item in list)
        //    {
        //        if (item is T)
        //        {
        //            numberOfT++;
        //        }
        //    }
        //    return numberOfT;
        //}

        /// <summary>
        /// Determines whether [has two close combat weapons].
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>
        ///   <c>true</c> if [has two close combat weapons] [the specified list]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasTwoCloseCombatWeapons(this IReadOnlyCollection<IEquipment> list)
        {
            return (CountNumberOf<ICloseCombatWeapon>(list) >= 2);
        }

        /// <summary>
        /// Determines whether [has two identical close combat weapons].
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>
        ///   <c>true</c> if [has two identical close combat weapons] [the specified list]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasTwoIdenticalCloseCombatWeapons(this IReadOnlyCollection<IEquipment> list)
        {
            List<ICloseCombatWeapon> closeCombatList = new List<ICloseCombatWeapon>();

            foreach (var item in list)
            {
                if (item is ICloseCombatWeapon)
                {
                    ICloseCombatWeapon closeCombatWeapon = item as ICloseCombatWeapon;

                    if (closeCombatList.FirstOrDefault(x => x.Name.Equals(item.Name)) != null) { return true; }
                    if (closeCombatWeapon.CloseCombatSpecialRules.Any(x => x.Equals(CloseCombatWeaponRules.Pair))) { return true; }

                    closeCombatList.Add(item as ICloseCombatWeapon);
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether [is carrying heavy armor and shield].
        /// </summary>
        /// <param name="equipmentList">The equipment list.</param>
        /// <returns>
        ///   <c>true</c> if [is carrying heavy armor and shield] [the specified equipment list]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCarryingHeavyArmorAndShield(this IReadOnlyCollection<IEquipment> equipmentList)
        {
            bool holdsHeavyArmor = false;
            bool holdsShield = false;

            foreach (var item in equipmentList)
            {
                if (item is HeavyArmor) { holdsHeavyArmor = true; }
                if (item is Shield) { holdsShield = true; }
            }

            return holdsHeavyArmor && holdsShield;
        }

        /// <summary>
        /// Maximums the close combat weapons reached.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>true if the Maximum of 2 is reached</returns>
        public static bool MaximumCloseCombatWeaponsReached(this IWarrior warrior)
        {
            if (CountNumberOf<ICloseCombatWeapon>(warrior.Equipment) >= warrior.MaximumCloseCombatWeapons)
            {
                return true;
            }

            List<ICloseCombatWeapon> closeCombatList = new List<ICloseCombatWeapon>();
            foreach (var item in warrior.Equipment)
            {
                if (item is ICloseCombatWeapon)
                {
                    ICloseCombatWeapon closeCombatWeapon = item as ICloseCombatWeapon;

                    if (closeCombatWeapon.CloseCombatSpecialRules.Any(x => x.Equals(CloseCombatWeaponRules.Pair))) { return true; }

                    closeCombatList.Add(item as ICloseCombatWeapon);
                }
            }

            return false;
        }

        /// <summary>
        /// To the many ranged weapons.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>true if the Maximum is 2 exceeded</returns>
        public static bool MaximumRangedWeaponsReached(this IReadOnlyCollection<IEquipment> list)
        {
            return (CountNumberOf<IMisseleWeapon>(list) >= MAXIMUM_NUMBER_OF_WEAPONS);
        }
    }
}