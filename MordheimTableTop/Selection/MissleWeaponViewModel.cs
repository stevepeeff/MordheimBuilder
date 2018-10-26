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
        public IMisseleWeapon MisseleWeapon { get; }

        public MissleWeaponViewModel(IMisseleWeapon misseleWeapon)
        {
            MisseleWeapon = misseleWeapon;
        }

        public int Costs => MisseleWeapon.Cost;

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
        public int Strength => MisseleWeapon.Strength;
        public int Range => MisseleWeapon.Range;
    }
}