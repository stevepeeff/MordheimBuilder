using DomainModel.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class MissileWeaponViewModel
    {
        internal IMisseleWeapon MisseleWeapon { get; private set; }

        public MissileWeaponViewModel(IMisseleWeapon misseleWeapon)
        {
            if (misseleWeapon == null) { throw new ArgumentNullException("IMisseleWeapon is null"); }
            MisseleWeapon = misseleWeapon;
        }

        #region DO NOT reorganize this ViewModel

        public string Name
        {
            get { return FormattingTools.SplitCamelCasing(MisseleWeapon.Name); }
        }

        public string Effects
        {
            get
            {
                string result = String.Empty;

                foreach (var item in MisseleWeapon.MisseleWeaponSpecialRules)
                {
                    result += $"{item} ";
                    EffectsDescription += item.GetDescription();
                }
                return result.SplitCamelCasing();
            }
        }

        public string Strength
        {
            get
            {
                if (MisseleWeapon.Strength != 0)
                {
                    return MisseleWeapon.Strength.ToString();
                }
                return "-";
            }
        }

        public int Range
        {
            get
            {
                return MisseleWeapon.Range;
            }
        }

        public int Costs { get { return MisseleWeapon.Cost; } }

        internal string EffectsDescription { get; private set; }

        #endregion DO NOT reorganize this ViewModel
    }
}