using System;
using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Injuries;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands
{
    public enum OverallResults
    {
        Normal,
        Positive,
        Negative
    }

    public class Characteristic
    {
        public const int ARMOUR_SAVE_NONE = 0;
        private int? _MaximumValue = null;

        private WarriorBase _Warrior;

        public Characteristic(IWarrior owner, Characteristics characteristicValue, int baseValue)
        {
            _Warrior = (WarriorBase)owner;
            CharacteristicValue = characteristicValue;
            BaseValue = baseValue;
        }

        /// <summary>
        /// Occurs when [characteristic changed].
        /// </summary>
        public event EventHandler CharacteristicChanged;

        /// <summary>
        /// Gets or sets the base value.
        /// </summary>
        /// <value>
        /// The base value.
        /// </value>
        public int BaseValue { get; set; }

        /// <summary>
        /// Gets the calculated value.
        /// </summary>
        /// <value>
        /// The calculated value.
        /// </value>
        public int CalculatedValue
        {
            get
            {
                if (CharacteristicValue == Characteristics.Save)
                {
                    return CalculateArmourSave();
                }

                return CalculateCharactaristic();
            }
        }

        /// <summary>
        /// Gets the characteristic value.
        /// </summary>
        /// <value>
        /// The characteristic value.
        /// </value>
        public Characteristics CharacteristicValue { get; private set; }

        public string LabelName
        {
            get
            {
                string retval = "-";
                switch (CharacteristicValue)
                {
                    case Characteristics.None:
                        break;

                    case Characteristics.Movement:
                        retval = "M";
                        break;

                    case Characteristics.Attack:
                        retval = "A";
                        break;

                    case Characteristics.Toughness:
                        retval = "T";
                        break;

                    case Characteristics.Initiative:
                        retval = "I";
                        break;

                    case Characteristics.Strength:
                        retval = "S";
                        break;

                    case Characteristics.WeaponSkill:
                        retval = "WS";
                        break;

                    case Characteristics.BallisticSkill:
                        retval = "BS";
                        break;

                    case Characteristics.Wounds:
                        retval = "W";
                        break;

                    case Characteristics.LeaderShip:
                        retval = "Ld";
                        break;

                    case Characteristics.Wealth:
                        retval = "Wealth";
                        break;

                    case Characteristics.Save:
                        retval = "Sv";
                        break;

                    default:
                        retval = "NOT SET";
                        break;
                }
                return retval;
            }
        }

        /// <summary>
        /// Gets or sets the maximum value.
        /// </summary>
        /// <value>
        /// The maximum value.
        /// </value>
        /// <exception cref="NotImplementedException"></exception>
        public int MaximumValue
        {
            get

            {
                int retval = 0;
                if (_Warrior is IHenchMan)
                {
                    retval = BaseValue + 1;
                }
                if (_MaximumValue.HasValue)
                {
                    retval = _MaximumValue.Value;
                }

                return retval;
            }
            set { _MaximumValue = value; }
        }

        public OverallResults OverallResult
        {
            get
            {
                if (CalculatedValue < BaseValue)
                {
                    return OverallResults.Negative;
                }
                if (CalculatedValue > BaseValue)
                {
                    return OverallResults.Positive;
                }
                return OverallResults.Normal;
            }
        }

        /// <summary>
        /// Invokes the characteristic changed.
        /// </summary>
        public void InvokeCharacteristicChanged()
        {
            EventHandler handler = CharacteristicChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private int CalculateArmourSave()
        {
            int calculatedArmorSave = ARMOUR_SAVE_NONE;

            foreach (IEquipment item in _Warrior.Equipment)
            {
                IArmour armour = item as IArmour;

                if (armour != null)
                {
                    calculatedArmorSave += armour.Save;
                }
            }
            return calculatedArmorSave;
        }

        private int CalculateCharactaristic()
        {
            int calculation = 0;

            if (_Warrior is IHero)
            {
                IHero hero = (IHero)_Warrior;
                calculation += CalculateSkill(hero);
                calculation += CalculateInjury(hero);
            }
            calculation += CalculateRacialAdvantageModifier();

            return BaseValue + calculation;
        }

        private int CalculateInjury(IHero hero)
        {
            int heroModifier = 0;

            foreach (Injury injury in hero.Injuries)
            {
                if (CharacteristicValue == injury.Result.Characteristic)
                {
                    heroModifier += injury.Result.AppliedValue;
                }
            }

            return heroModifier;
        }

        private int CalculateRacialAdvantageModifier()
        {
            int racialAdvantage = 0;

            if (_Warrior.Advantages != null)
            {
                foreach (var statistic in _Warrior.Advantages.Statistics)
                {
                    if (CharacteristicValue == statistic.Characteristic)
                    {
                        racialAdvantage += statistic.AppliedValue;
                    }
                }
            }
            return racialAdvantage;
        }

        private int CalculateSkill(IHero hero)
        {
            int heroModifier = 0;

            foreach (ISkill skill in hero.Skills)
            {
                foreach (var statistic in skill.Statistics)
                {
                    if (CharacteristicValue == statistic.Characteristic)
                    {
                        heroModifier += statistic.AppliedValue;
                    }
                }
            }

            return heroModifier;
        }
    }
}