﻿using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Psychology;
using DomainModel.RacialAdvantages;
using DomainModel.Skills;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using DomainModel.WarriorStatus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class WarriorBase : IWarrior
    {
        public const int INFINITE = int.MaxValue;
        protected List<ISkill> _AllowedSkills = new List<ISkill>();
        protected List<ISkill> _Skills = new List<ISkill>();
        private List<Characteristic> _Characteristics;
        private int _CurrentExperience = 0;

        protected List<CharacteristicModifier> _CharacteristicModifiers = new List<CharacteristicModifier>();

        /// <summary>
        /// Gets the characteristic modifiers.
        /// </summary>
        /// <param name="characteristic">The characteristic.</param>
        /// <returns></returns>
        internal List<CharacteristicModifier> GetCharacteristicModifiers(Characteristics characteristic)
        {
            CalculateCharacteristicsModifiers();
            return _CharacteristicModifiers.Where(x => x.Characteristic.Equals(characteristic)).ToList();
        }

        public WarriorBase()
        {
            Movement = new Characteristic(this, Characteristics.Movement, 4);
            WeaponSkill = new Characteristic(this, Characteristics.WeaponSkill, 3);
            BallisticSkill = new Characteristic(this, Characteristics.BallisticSkill, 3);
            Strength = new Characteristic(this, Characteristics.Strength, 3);
            Toughness = new Characteristic(this, Characteristics.Toughness, 3);
            Wounds = new Characteristic(this, Characteristics.Wounds, 1);
            Initiative = new Characteristic(this, Characteristics.Initiative, 3);
            Attacks = new Characteristic(this, Characteristics.Attack, 1);
            LeaderShip = new Characteristic(this, Characteristics.LeaderShip, 7);
            Save = new Characteristic(this, Characteristics.Save, 0);

            _Characteristics = new List<Characteristic>()
            {
                Movement,WeaponSkill, BallisticSkill, Strength, Toughness, Wounds, Initiative, Attacks, LeaderShip, Save
            };
        }

        public IRacialAdvantage Advantages { get; protected set; }

        public IReadOnlyCollection<IPsychology> Afflictions
        { get { return _Afflictions; } }

        public IReadOnlyCollection<IEquipment> AllowedEquipment
        { get { return _AllowedWeapons; } }

        public IReadOnlyCollection<ISkill> AllowedSkills
        { get { return _AllowedSkills; } }

        public int AmountInGroup { get; private set; } = 0;
        public Characteristic Attacks { get; private set; }
        public Characteristic BallisticSkill { get; private set; }
        public DateTime? CreationDate { get; private set; } = null;

        public int CurrentExperience
        {
            get { return InitialExperience + _CurrentExperience; }
        }

        protected virtual void CalculateCharacteristicsModifiers()
        {
            _CharacteristicModifiers.Clear();
            if (Advantages != null)
            {
                foreach (var statistic in Advantages.Statistics)
                {
                    _CharacteristicModifiers.Add(new CharacteristicModifier(statistic));
                }
            }
        }

        public IReadOnlyCollection<IEquipment> Equipment
        { get { return _EquipmentList; } }

        public virtual int EquipmentCosts
        {
            get
            {
                int totalCosts = 0;
                bool firstOneFree = true;
                foreach (var item in Equipment)
                {
                    if (item is Dagger && firstOneFree)//NOT A PROPER implementation , should handle 'First One Free'
                    {
                        firstOneFree = false;
                    }
                    else
                    {
                        totalCosts += item.Cost;
                    }
                }

                return totalCosts;
            }
        }

        public int? GroupCosts
        {
            get
            {
                if (this is IHenchMen)
                {
                    IHenchMen henchMen = this as IHenchMen;
                    return (henchMen.AmountInGroup * (this.EquipmentCosts + this.HireFee));
                }

                return null;
            }
        }

        public int? GroupCount
        {
            get
            {
                if (this is IHenchMen)
                {
                    IHenchMen henchMen = this as IHenchMen;
                    return henchMen.AmountInGroup;
                }

                return null;
            }
        }

        public abstract int HireFee { get; }
        public virtual int InitialExperience { get; }
        public Characteristic Initiative { get; private set; }
        public Characteristic LeaderShip { get; private set; }
        public virtual IReadOnlyCollection<int> LevelUpValues { get; }
        public abstract int MaximumAllowedInWarBand { get; }

        public virtual int MaximumCloseCombatWeapons
        {
            get
            {
                return EquipmentTools.MAXIMUM_NUMBER_OF_WEAPONS;
            }
        }

        public virtual int MaximumExperience { get; } = 14;
        public int MaximumMissileWeapons => EquipmentTools.MAXIMUM_NUMBER_OF_WEAPONS;
        public Characteristic Movement { get; private set; }
        public string Name { get; set; }
        public Characteristic Save { get; private set; }

        public IReadOnlyCollection<ISkill> Skills
        { get { return _Skills; } }

        public Characteristic Strength { get; private set; }
        public Characteristic Toughness { get; private set; }

        public string TypeName
        { get { return this.GetType().Name; } }

        public IWarriorStatus WarriorStatus { get; private set; } = new InAction();

        public Characteristic WeaponSkill { get; private set; }

        public Characteristic Wounds { get; private set; }

        protected List<IEquipment> _AllowedWeapons { get; set; } = new List<IEquipment>();

        protected List<IEquipment> _EquipmentList { get; } = new List<IEquipment>();

        private List<IPsychology> _Afflictions { get; } = new List<IPsychology>();

        public static bool LevelUpCalculationHenchMan(int experienceValue)
        {
            int cumulative = 0;
            for (int i = 2; i <= 5; i++)
            {
                cumulative += i;
                if (cumulative == experienceValue) { return true; }
                if (cumulative > experienceValue) { return false; }
            }

            return false;
        }

        public void AddAffliction(IPsychology affliction)
        {
            _Afflictions.Add(affliction);
        }

        public void AddEquipment(string name)
        {
            AddEquipment(EquipmentProvider.Instance.GetEquipment(name));
        }

        public bool AddEquipment(IEquipment equipment)
        {
            bool addOfquipmntIsAllowd = false;
            if (equipment is IArmour)
            {
                if (_EquipmentList.Any(x => x.Name.Equals(equipment.Name)) == false &&
                    _EquipmentList.HasArmourEquipped(equipment) == false)
                {
                    _EquipmentList.Add(equipment);
                    addOfquipmntIsAllowd = true;
                }
            }
            else if (equipment is ICloseCombatWeapon)
            {
                if (this.MaximumCloseCombatWeaponsReached() == false)
                {
                    _EquipmentList.Add(equipment);
                    addOfquipmntIsAllowd = true;
                }
            }
            else if (equipment is IMisseleWeapon)
            {
                if (_EquipmentList.MaximumRangedWeaponsReached() == false)
                {
                    _EquipmentList.Add(equipment);
                    addOfquipmntIsAllowd = true;
                }
            }

            TriggerCharacteristicChanged();
            return addOfquipmntIsAllowd;
        }

        public void AddSkill(ISkill skill)
        {
            _Skills.Add(skill);
            TriggerCharacteristicChanged();
        }

        public void AddSkill(string skillName)
        {
            _Skills.Add(SkillProvider.Instance.GetSkill(skillName));
        }

        public int AmountOfThisType(IWarrior warrior)
        {
            if (this.TypeName.Equals(warrior.TypeName))
            {
                IHenchMen henchMan = this as IHenchMen;

                if (henchMan != null)
                {
                    return henchMan.AmountInGroup;
                }
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Verifies if this and another warrior
        /// TODO obsolete, so remove
        /// </summary>
        /// <param name="warrior">The warrior.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">warrior is null</exception>
        public bool AreEqual(IWarrior warrior)
        {
            if (warrior == null) { throw new ArgumentNullException("warrior is null"); }

            bool areEqual =
                warrior.GetType().Name.Equals(this.GetType().Name) &&
                warrior.CurrentExperience == this.CurrentExperience &&
                this.CreationDate != null &&
                this.GetHashCode() == warrior.GetHashCode();

            return areEqual;
        }

        public void ChangeStatus(IWarriorStatus warriorStatus)
        {
            WarriorStatus = warriorStatus;
        }

        public void DecreaseGroupByOne()
        {
            AmountInGroup--;
            //NotifyPropertiesChangedChanged();
        }

        public abstract IWarrior GetANewInstance();

        public IWarrior GetAnInstance()
        {
            IWarrior newInstance = GetANewInstance();
            WarriorBase warriorBase = newInstance as WarriorBase;
            warriorBase.CreationDate = DateTime.Now;

            return newInstance;
        }

        public void IncreaseGroupByOne()
        {
            AmountInGroup++;
            //NotifyPropertiesChangedChanged();
        }

        public virtual bool IsLevelUp(int experienceValue)
        {
            return LevelUpCalculationHenchMan(experienceValue);
        }

        public void RemoveEquipment(IEquipment equipment)
        {
            _EquipmentList.Remove(equipment);
            // NotifyPropertiesChangedChanged();
            if (equipment is IArmour)
            {
                TriggerCharacteristicChanged();
            }
        }

        /// <summary>
        /// Triggers the characteristic changed.
        /// </summary>
        protected void TriggerCharacteristicChanged()
        {
            foreach (var item in _Characteristics)
            {
                item.InvokeCharacteristicChanged();
            }
        }

        public virtual bool AddMutation(IMutation mutation)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveMutation(IMutation mutation)
        {
            throw new NotImplementedException();
        }
    }
}