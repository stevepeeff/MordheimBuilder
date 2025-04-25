using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Equipment
{
    public static class EquipmentTools
    {
        internal const int MAXIMUM_NUMBER_OF_WEAPONS = 2;

        /// <summary>
        /// Counts the number of.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static int CountNumberOf<T>(this IReadOnlyCollection<IEquipment> list) where T : IEquipment
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

        /// <summary>
        /// Determines whether [has armour equipped] [the specified equipment].
        /// </summary>
        /// <param name="equipmentList">The equipment list.</param>
        /// <param name="equipment">The equipment.</param>
        /// <returns>
        ///   <c>true</c> if [has armour equipped] [the specified equipment]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasArmourEquipped(this IReadOnlyCollection<IEquipment> equipmentList, IEquipment equipment)
        {
            if (equipment.IsArmour())
            {
                return equipmentList.Any(x => x.IsArmour());
            }
            return false;
        }

        /// <summary>
        /// Determines whether [has heavy armor and shield].
        /// </summary>
        /// <param name="equipmentList">The equipment list.</param>
        /// <returns>
        ///   <c>true</c> if [has heavy armor and shield] [the specified equipment list]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasHeavyArmorAndShield(this IReadOnlyCollection<IEquipment> equipmentList)
        {
            bool holdsHeavyArmor = false;
            bool holdsShield = false;

            foreach (var item in equipmentList)
            {
                if (item is HeavyArmour) { holdsHeavyArmor = true; }
                if (item is Shield) { holdsShield = true; }
            }

            return holdsHeavyArmor && holdsShield;
        }

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
        /// Determines whether this instance is armour.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        /// <returns>
        ///   <c>true</c> if the specified equipment is armour; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsArmour(this IEquipment equipment)
        {
            bool isArmour = false;

            if (equipment is HeavyArmour ||
                equipment is LightArmour ||
                equipment is IthilmarArmour ||
                equipment is GromhilArmour)
            {
                isArmour = true;
            }

            return isArmour;
        }

        /// <summary>
        /// Maximums the close combat weapons reached.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>true if the Maximum of 2 is reached or the warrior is carrying a Double handed weapon</returns>
        public static bool MaximumCloseCombatWeaponsReached(this IWarrior warrior)
        {
            if (CountNumberOf<ICloseCombatWeapon>(warrior.Equipment) >= warrior.MaximumCloseCombatWeapons) { return true; }
            if (warrior.Equipment.Any(x => x is DoubleHandedWeapon)) { return true; }

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