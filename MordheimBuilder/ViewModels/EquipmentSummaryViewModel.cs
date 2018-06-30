using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class EquipmentSummaryViewModel : ViewModelBase
    {
        private const string NONE = "None";
        private IArmour _Armor;
        private ICloseCombatWeapon _CloseCombatWeapon;
        private IMisseleWeapon _MisseleWeapon;
        private IWeapon _Weapon;

        public EquipmentSummaryViewModel(IEquipment equipment)
        {
            Equipment = equipment;
            _Weapon = Equipment as IWeapon;
            _MisseleWeapon = Equipment as IMisseleWeapon;
            _CloseCombatWeapon = Equipment as ICloseCombatWeapon;
            _Armor = Equipment as IArmour;
        }

        /// <summary>
        /// Gets the effects description.
        /// </summary>
        /// <value>
        /// The effects description.
        /// </value>
        internal string EffectsDescription { get; private set; }

        internal IEquipment Equipment { get; private set; }

        #region DO NOT reorganize this ViewModel

        public string AtMod
        {
            get
            {
                if (_CloseCombatWeapon != null)
                {
                    if (_CloseCombatWeapon.AttackModifier == 0) { return NONE; }
                    return $"+{_CloseCombatWeapon.AttackModifier}";
                }
                return "-";
            }
        }

        public string Effects
        {
            get
            {
                string result = String.Empty;
                if (_MisseleWeapon != null)
                {
                    foreach (var item in _MisseleWeapon.MisseleWeaponSpecialRules)
                    {
                        result += $"{item} ";
                        EffectsDescription += item.GetDescription();
                    }
                }
                if (_CloseCombatWeapon != null)
                {
                    foreach (var item in _CloseCombatWeapon.CloseCombatSpecialRules)
                    {
                        result += $"{item} ";
                        EffectsDescription += item.GetDescription();
                    }
                }
                if (_Armor != null)
                {
                    foreach (var item in _Armor.ArmourSpecialRules)
                    {
                        result += $"{item} ";
                        EffectsDescription += item.GetDescription();
                    }
                }
                return result.SplitCamelCasing();
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return FormattingTools.SplitCamelCasing(Equipment.Name);
            }
        }

        public string Rng
        {
            get
            {
                if (_MisseleWeapon != null)
                {
                    return _MisseleWeapon.Range.ToString();
                }

                return "N/A";
            }
        }

        public string St
        {
            get
            {
                if (_MisseleWeapon != null)
                {
                    if (_MisseleWeapon.Strength == 0)
                    {
                        return "As User";
                    }

                    return $"{_MisseleWeapon.Strength}";
                }
                return String.Empty;
            }
        }

        public string StMod
        {
            get
            {
                if (_CloseCombatWeapon != null)
                {
                    if (_CloseCombatWeapon.StrengthModifier > 0)
                    {
                        return $"+{_CloseCombatWeapon.StrengthModifier}";
                    }
                    else if (_CloseCombatWeapon.StrengthModifier == 0)
                    {
                        return NONE;
                    }
                    else if (_CloseCombatWeapon.StrengthModifier < 0)
                    {
                        return $"{_CloseCombatWeapon.StrengthModifier}";
                    }
                }
                return String.Empty;
            }
        }

        public string Sv
        {
            get
            {
                if (_Armor != null)
                {
                    return ArmorViewModel.FormatSaveModifier(_Armor);
                }
                else if (_CloseCombatWeapon != null && _CloseCombatWeapon.ArmorSaveModifier != 0)
                {
                    return ArmorViewModel.FormatSaveValue(_CloseCombatWeapon.ArmorSaveModifier);
                }

                return "-";
            }
        }

        public string ToHit
        {
            get
            {
                if (_CloseCombatWeapon != null)
                {
                    int modifier = _CloseCombatWeapon.ToHitModifier;

                    if (modifier > 0)
                    {
                        return $"+{modifier}";
                    }
                    else if (modifier == 0)
                    {
                        return $"None";
                    }
                    else if (modifier < 0)
                    {
                        return $"{modifier}";
                    }
                }
                return String.Empty;
            }
        }

        #endregion DO NOT reorganize this ViewModel
    }
}