using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Injuries;
using DomainModel.Skills;
using DomainModel.Warbands.BaseClasses;
using System;

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
                ModifierSummary = null;
                if (CharacteristicValue == Characteristics.Save)
                {
                    return CalculateArmourSave();
                }
                else
                {
                    int calculation = 0;

                    foreach (var item in _Warrior.GetCharacteristicModifiers(CharacteristicValue))
                    {
                        calculation += item.Modifier;
                        AddModifierComment(item.Description);
                    }

                    switch (CharacteristicValue)
                    {
                        case Characteristics.Movement:
                            {
                                if (_Warrior.Equipment.HasHeavyArmorAndShield())
                                {
                                    calculation--;
                                    AddModifierComment("Heavy Armour and Shield causes a movement penalty of -1");
                                }
                            }
                            break;

                        case Characteristics.Attack:
                            {
                                if (_Warrior.Equipment.HasTwoIdenticalCloseCombatWeapons())
                                {
                                    calculation++;
                                    AddModifierComment("Attack bonus of +1, when using 2 identical weapons");
                                }
                                else if (_Warrior.Equipment.HasTwoCloseCombatWeapons())
                                {
                                    calculation++;
                                    AddModifierComment("Attack bonus of +1, when using 2 weapons ");
                                    AddModifierComment("(Roll for each weapon separately)");
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

        /// <summary>
        /// Gets the modifier summary.
        /// </summary>
        /// <value>
        /// The modifier summary.
        /// </value>
        public string ModifierSummary { get; private set; }

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
            if (CharacteristicChanged != null)
            {
                CharacteristicChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private void AddModifierComment(string comment)
        {
            if (String.IsNullOrEmpty(ModifierSummary) == false)
            {
                ModifierSummary = ModifierSummary + Environment.NewLine;
            }
            ModifierSummary += comment;
        }

        private int CalculateArmourSave()
        {
            int calculatedArmorSave = ARMOUR_SAVE_NONE;

            foreach (IEquipment item in _Warrior.Equipment)
            {
                IArmour armour = item as IArmour;
                if (armour != null)
                {
                    AddModifierComment(armour.Name);
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
                    AddModifierComment(injury.Name);
                    AddModifierComment(injury.Description);
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
                        AddModifierComment(_Warrior.Advantages.Description);
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
                        AddModifierComment(skill.SkillName);
                    }
                }
            }

            return heroModifier;
        }
    }
}