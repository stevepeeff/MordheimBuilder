using DomainModel.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop.Selection
{
    internal class MissleWeaponViewModel : ViewModelBase
    {
        public MissleWeaponViewModel(IMisseleWeapon misseleWeapon)
        {
            MisseleWeapon = misseleWeapon;
        }

        public int Costs => MisseleWeapon.Cost;

        public string ArmourSaveModifier
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

        public string Description
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

        public string Name => MisseleWeapon.Name.SplitCamelCasing();
        public int Range => MisseleWeapon.Range;
        public int Strength => MisseleWeapon.Strength;
        internal IMisseleWeapon MisseleWeapon { get; }
    }
}