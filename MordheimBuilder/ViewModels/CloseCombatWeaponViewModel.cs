using DomainModel.Equipment;
using DomainModel.Equipment.Weapons.CloseCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class CloseCombatWeaponViewModel
    {
        internal ICloseCombatWeapon CloseCombatWeapon { get; private set; }

        public CloseCombatWeaponViewModel(ICloseCombatWeapon closeCombatWeapon)
        {
            if (closeCombatWeapon == null) { throw new ArgumentNullException("ICloseCombatWeapon is null"); }
            CloseCombatWeapon = closeCombatWeapon;
        }

        #region DO NOT reorganize this ViewModel

        public string Name
        {
            get { return FormattingTools.SplitCamelCasing(CloseCombatWeapon.Name); }
        }

        public string Effects
        {
            get
            {
                string result = String.Empty;

                foreach (var item in CloseCombatWeapon.CloseCombatSpecialRules)
                {
                    result += $"{item} ";
                    EffectsDescription += item.GetDescription();
                }
                return result.SplitCamelCasing();
            }
        }

        public string StrengthModifier
        {
            get
            {
                if (CloseCombatWeapon.StrengthModifier != 0)
                {
                    return $"+{CloseCombatWeapon.StrengthModifier}";
                }
                return "-";
            }
        }

        public string AttackModifier
        {
            get
            {
                //if (CloseCombatWeapon.AttackModifier != 0)
                //{
                //    return CloseCombatWeapon.AttackModifier.ToString();
                //}
                return "TP DO Where is this used??";
            }
        }

        public string ToHitModifier
        {
            get
            {
                if (CloseCombatWeapon.ToHitModifier != 0)
                {
                    return CloseCombatWeapon.ToHitModifier.ToString();
                }
                return "-";
            }
        }

        public int Costs { get { return CloseCombatWeapon.Cost; } }

        internal string EffectsDescription { get; private set; }

        internal IEquipment Equipment { get { return CloseCombatWeapon; } }

        #endregion DO NOT reorganize this ViewModel
    }
}