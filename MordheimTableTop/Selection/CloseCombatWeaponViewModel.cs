using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimTableTop.Selection
{
    public class CloseCombatWeaponViewModel : EquipmentViewModel
    {
        public CloseCombatWeaponViewModel(ICloseCombatWeapon closeCombatWeapon)
        {
            CloseCombatWeapon = closeCombatWeapon;
        }

        internal ICloseCombatWeapon CloseCombatWeapon { get; }

        public override int Costs => CloseCombatWeapon.Cost;

        public override string Description
        {
            get
            {
                string description = String.Empty;
                foreach (var item in CloseCombatWeapon.CloseCombatSpecialRules)
                {
                    if (!String.IsNullOrEmpty(description))
                    {
                        description += ",";
                    }
                    description += item.GetDescription();
                }

                return description;
            }
        }

        public override string Name => CloseCombatWeapon.Name.SplitCamelCasing();

        public override string StrengthModifier
        {
            get
            {
                if (CloseCombatWeapon.StrengthModifier > 0)
                {
                    return $"+{CloseCombatWeapon.StrengthModifier}";
                }
                return "As User";
            }
        }

        public override string ArmourSaveModifier
        {
            get
            {
                if (CloseCombatWeapon.ArmorSaveModifier > 0)
                {
                    return $"+{CloseCombatWeapon.ArmorSaveModifier}";
                }
                if (CloseCombatWeapon.ArmorSaveModifier < 0)
                {
                    return $"{CloseCombatWeapon.ArmorSaveModifier}";
                }
                return "None";
            }
        }

        public override int ToHitModifier => CloseCombatWeapon.ToHitModifier;
    }
}