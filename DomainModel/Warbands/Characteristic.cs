using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Injuries;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.CultOfThePossessed.Mutations;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="Characteristic"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="characteristicValue">The characteristic value.</param>
        /// <param name="baseValue">The base value.</param>
        /// <exception cref="ArgumentNullException">IWarrrior is null</exception>
        public Characteristic(IWarrior owner, Characteristics characteristicValue, int baseValue)
        {
            if (owner == null) { throw new ArgumentNullException("IWarrrior is null"); }

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
                else
                {
                    //   int calculation = CalculateCharacteristic();

                    int calculation = 0;

                    foreach (var item in _Warrior.GetCharacteristicModifiers(CharacteristicValue))
                    {
                        calculation += item.Modifier;
                        _ModifierSummary.AppendLine(item.Description);
                    }

                    switch (CharacteristicValue)
                    {
                        case Characteristics.Movement:
                            {
                                if (_Warrior.Equipment.IsCarryingHeavyArmorAndShield())
                                {
                                    calculation--;
                                    _ModifierSummary.AppendLine("Heavy Armour and Shield causes a movement penalty of -1");
                                    _EquipmentComment = "Heavy Armour and Shield causes a movement penalty of -1";
                                }
                            }
                            break;

                        case Characteristics.Attack:
                            {
                                if (_Warrior.Equipment.HasTwoIdenticalCloseCombatWeapons())
                                {
                                    calculation++;
                                    _ModifierSummary.AppendLine("Attack bonus of +1, when using 2 identical weapons");
                                    _EquipmentComment = "Attack bonus of +1, when using 2 identical weapons";
                                }
                                if (_Warrior.Equipment.HasTwoCloseCombatWeapons())
                                {
                                    calculation++;
                                    _ModifierSummary.AppendLine("Attack bonus of +1, when using 2 weapons ");
                                    _ModifierSummary.AppendLine("(Roll for each weapon separately)");
                                    _EquipmentComment =
                                        "Attack bonus of +1, when using 2 weapons " +
                                        Environment.NewLine + "(Roll for each weapon separately)";
                                }
                            }
                            break;
                    }

                    return BaseValue + calculation;
                }
            }
        }

        /// <summary>
        /// Gets the characteristic value.
        /// </summary>
        /// <value>
        /// The characteristic value.
        /// </value>
        public Characteristics CharacteristicValue { get; }

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
                if (_Warrior is IHenchMen)
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

        public string ModifierSummary
        {
            get
            {
                return _ModifierSummary.ToString();

                string summary = String.Empty;

                foreach (string item in BuildCharacteristicComment())
                {
                    if (String.IsNullOrEmpty(summary) == false)
                    {
                        summary += Environment.NewLine;
                    }
                    summary += item;
                }

                return summary;
            }
        }

        private StringBuilder _ModifierSummary = new StringBuilder();

        /// <summary>
        /// Gets the overall result.
        /// </summary>
        /// <value>
        /// The overall result.
        /// </value>
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

        private List<string> BuildCharacteristicComment()
        {
            List<string> descriptions = new List<string>();

            //TODO proper refactor, we only read the description of 'Statistic'

            if (CharacteristicValue == Characteristics.Save)
            {
                foreach (IEquipment item in _Warrior.Equipment)
                {
                    IArmour armour = item as IArmour;

                    if (armour != null)
                    {
                        descriptions.Add(armour.Description);
                    }
                }
            }
            else
            {
                if (_Warrior.Advantages != null)
                {
                    foreach (Statistic statistic in _Warrior.Advantages.Statistics)
                    {
                        if (CharacteristicValue == statistic.Characteristic)
                        {
                            descriptions.Add(statistic.Description);
                        }
                    }
                }

                foreach (ISkill skill in _Warrior.Skills)
                {
                    foreach (Statistic statistic in skill.Statistics)
                    {
                        if (CharacteristicValue == statistic.Characteristic)
                        {
                            descriptions.Add(statistic.Description);
                        }
                    }
                }

                IHero hero = _Warrior as IHero;
                if (hero != null)
                {
                    foreach (Injury injury in hero.Injuries)
                    {
                        if (CharacteristicValue == injury.Result.Characteristic)
                        {
                            descriptions.Add(injury.Result.Description);
                        }
                    }
                }
            }

            if (!String.IsNullOrWhiteSpace(_EquipmentComment))
            {
                descriptions.Add(_EquipmentComment);
            }

            return descriptions;
        }

        private string _EquipmentComment = String.Empty;

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

        private int CalculateCharacteristic()
        {
            int calculation = 0;

            if (_Warrior is IHero)
            {
                IHero hero = _Warrior as IHero;
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