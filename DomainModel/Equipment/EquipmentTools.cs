using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment
{
    public static class EquipmentTools
    {
        public static bool TwoIdenticalWeapons(this IReadOnlyCollection<IEquipment> list)
        {
            List<ICloseCombatWeapon> closeCombatList = new List<ICloseCombatWeapon>();

            foreach (var item in list)
            {
                if (item is IWeapon CountAsPair)
                {
                    IWeapon weapon = item as IWeapon;
                    if (weapon.CountsAsPair) { return true; }
                }

                if (item is ICloseCombatWeapon)
                {
                    if (closeCombatList.FirstOrDefault(x => x.Name.Equals(item.Name)) != null) { return true; }
                    closeCombatList.Add(item as ICloseCombatWeapon);
                }
            }

            return false;
        }

        public static bool TwoCloseCombatWeapons(this IReadOnlyCollection<IEquipment> list)
        {
            int numberOfCloseCombatWeapons = 0;

            foreach (var item in list)
            {
                if (item is ICloseCombatWeapon)
                {
                    numberOfCloseCombatWeapons++;
                }
            }

            return (numberOfCloseCombatWeapons > 2);
        }

        public static bool ToManyCloseCombatWeapons(this IReadOnlyCollection<IEquipment> list)
        {
            return false;
        }

        public static bool HoldsHeavyArmortAndShield(this IReadOnlyCollection<IEquipment> equipmentList)
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

        public static IEquipment HasPairSpecialRule(this IReadOnlyCollection<IEquipment> equipmentList)
        {
            foreach (IEquipment equipment in equipmentList)
            {
                if (equipment is ICloseCombatWeapon)
                {
                    ICloseCombatWeapon closeCombatWeapon = equipment as ICloseCombatWeapon;

                    foreach (var item in closeCombatWeapon.CloseCombatSpecialRules)
                    {
                        if (item == CloseCombatWeaponRules.Pair)
                        {
                            return equipment;
                        }
                    }
                }
            }

            return null;
        }
    }
}