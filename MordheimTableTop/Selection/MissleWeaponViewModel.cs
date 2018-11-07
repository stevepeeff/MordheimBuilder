using DomainModel.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Selection
{
    public class MissleWeaponViewModel : EquipmentViewModel
    {
        public MissleWeaponViewModel(IMisseleWeapon misseleWeapon)
        {
            MisseleWeapon = misseleWeapon;
        }

        public override int Costs => MisseleWeapon.Cost;

        public override string ArmourSaveModifier
        {
            get
            {
                if (MisseleWeapon.ArmorSaveModifier > 0)
                {
                    return $"+{MisseleWeapon.ArmorSaveModifier}";
                }
                if (MisseleWeapon.ArmorSaveModifier < 0)
                {
                    return $"{MisseleWeapon.ArmorSaveModifier}";
                }
                return "None";
            }
        }

        public override string Description
        {
            get
            {
                string description = String.Empty;
                foreach (var item in MisseleWeapon.MisseleWeaponSpecialRules)
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

        public override string Name => MisseleWeapon.Name.SplitCamelCasing();
        public override int Range => MisseleWeapon.Range;
        public override int Strength => MisseleWeapon.Strength;
        internal IMisseleWeapon MisseleWeapon { get; }
    }
}