using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Selection
{
    internal static class EquipmentViewModelFactory
    {
        public static ObservableCollection<EquipmentViewModel> ConvertToViewModelCollection(this IReadOnlyCollection<IEquipment> equipmentList)
        {
            var resultList = new ObservableCollection<EquipmentViewModel>();

            foreach (var item in equipmentList)
            {
                if (item is IArmour)
                {
                    resultList.Add(new ArmourViewModel(item as IArmour));
                }
                else if (item is ICloseCombatWeapon)
                {
                    resultList.Add(new CloseCombatWeaponViewModel(item as ICloseCombatWeapon));
                }
                else if (item is IMisseleWeapon)
                {
                    resultList.Add(new MissleWeaponViewModel(item as IMisseleWeapon));
                }
                else if (item is IMutation)
                {
                    resultList.Add(new MutationViewModel(item as IMutation));
                }
                else
                {
                    //TODO Ad  logging
                }
            }

            return resultList;
        }
    }
}