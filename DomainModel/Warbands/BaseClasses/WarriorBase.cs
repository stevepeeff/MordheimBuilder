using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Equipment;
using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Psychology;
using DomainModel.RacialAdvantages;
using DomainModel.Skills;
using DomainModel.WarriorStatus;

namespace DomainModel.Warbands.BaseClasses
{
    public abstract class WarriorBase : IWarrior
    {
        protected List<ISkill> _AllowedSkills = new List<ISkill>();
        protected List<ISkill> _Skills = new List<ISkill>();
        private List<Characteristic> _Characteristics;

        private int _CurrentExperience = 0;

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

            _AllowedWeapons.Add(new Dagger());
        }

        public IWarriorStatus WarriorStatus { get; private set; } = new InAction();

        public void ChangeStatus(IWarriorStatus warriorStatus)
        {
            WarriorStatus = warriorStatus;
        }

        public event EventHandler PropertiesChanged;

        public IRacialAdvantage Advantages { get; protected set; }
        public IReadOnlyCollection<IPsychology> Afflictions { get { return _Afflictions; } }
        public IReadOnlyCollection<IEquipment> AllowedEquipment { get { return _AllowedWeapons; } }
        public IReadOnlyCollection<ISkill> AllowedSkills { get { return _AllowedSkills; } }
        public Characteristic Attacks { get; private set; }
        public Characteristic BallisticSkill { get; private set; }
        public DateTime? CreationDate { get; private set; } = null;

        public int CurrentExperience
        {
            get { return InitialExperience + _CurrentExperience; }
            //   protected set { _CurrentExperience = value; }
        }

        public IReadOnlyCollection<IEquipment> Equipment { get { return _Weapons; } }

        public int EquipmentCosts
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
                if (this is IHenchMan)
                {
                    IHenchMan henchMen = this as IHenchMan;
                    return (henchMen.AmountInGroup * (this.EquipmentCosts + this.HireFee));
                }

                return null;
            }
        }

        public int? GroupCount
        {
            get
            {
                if (this is IHenchMan)
                {
                    IHenchMan henchMen = this as IHenchMan;
                    return henchMen.AmountInGroup;
                }

                return null;
            }
        }

        public void AddSkill(ISkill skill)
        {
            _Skills.Add(skill);
            Trigger();
        }

        public void AddSkill(string skillName)
        {
            _Skills.Add(SkillProvider.Instance.GetSkill(skillName));
        }

        public IReadOnlyCollection<ISkill> Skills { get { return _Skills; } }

        public abstract int HireFee { get; }
        public virtual int InitialExperience { get; }
        public Characteristic Initiative { get; private set; }
        public Characteristic LeaderShip { get; private set; }
        public virtual IReadOnlyCollection<int> LevelUpValues { get; }
        public abstract int MaximumAllowedInWarBand { get; }
        public virtual int MaximumExperience { get; } = 14;
        public Characteristic Movement { get; private set; }
        public string Name { get; set; }
        public int AmountInGroup { get; private set; } = 0;
        public Characteristic Save { get; private set; }

        public Characteristic Strength { get; private set; }

        public Characteristic Toughness { get; private set; }

        public string TypeName { get { return this.GetType().Name; } }

        public Characteristic WeaponSkill { get; private set; }

        public Characteristic Wounds { get; private set; }

        protected List<IEquipment> _AllowedWeapons { get; } = new List<IEquipment>();

        protected List<IEquipment> _Weapons { get; } = new List<IEquipment>();

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

        public void AddEquipment(IEquipment equipment)
        {
            _Weapons.Add(equipment);
            NotifyPropertiesChangedChanged();
            if (equipment is IArmour)
            {
                Trigger();
            }
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

        public void DecreaseGroupByOne()
        {
            AmountInGroup--;
            NotifyPropertiesChangedChanged();
        }

        public virtual bool IsLevelUp(int experienceValue)
        {
            return LevelUpCalculationHenchMan(experienceValue);
        }

        public abstract IWarrior GetANewInstance();

        //public IWarrior GetAnInstance(string typeOfWarrior)
        //{
        //    IWarrior result = null;
        //    if (TypeName.Equals(typeOfWarrior))
        //    {
        //        result = GetAnInstance();
        //        //TODO SET THE CREATION DATE
        //    }
        //    return result;
        //}

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
            NotifyPropertiesChangedChanged();
        }

        public int AmountOfThisType(IWarrior warrior)
        {
            if (this.TypeName.Equals(warrior.TypeName))
            {
                IHenchMan henchMan = this as IHenchMan;

                if (henchMan != null)
                {
                    return henchMan.AmountInGroup;
                }
                return 1;
            }
            return 0;
        }

        public void RemoveEquipment(IEquipment equipment)
        {
            _Weapons.Remove(equipment);
            NotifyPropertiesChangedChanged();
            if (equipment is IArmour)
            {
                Trigger();
            }
        }

        protected void Trigger()
        {
            foreach (var item in _Characteristics)
            {
                item.InvokeCharacteristicChanged();
            }
        }

        private void NotifyPropertiesChangedChanged()
        {
            EventHandler handler = PropertiesChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}