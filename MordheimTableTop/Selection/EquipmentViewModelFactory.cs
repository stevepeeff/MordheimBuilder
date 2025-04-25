using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using System.Collections.ObjectModel;

namespace MordheimTableTop.Selection
{
    internal static class EquipmentViewModelFactory
    {
        public static ObservableCollection<EquipmentViewModel> EquipmentAndMutattionsToViewModel(this IWarrior warrior)
        {
            var resultList = new ObservableCollection<EquipmentViewModel>();

            foreach (var item in warrior.Equipment)
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
                else
                {
                    //TODO Ad  logging
                }
            }

            if (warrior is IMutant)
            {
                IMutant mutant = warrior as IMutant;

                foreach (var item in mutant.Mutations)
                {
                    resultList.Add(new MutationViewModel(item as IMutation));
                }
            }

            return resultList;
        }
    }
}