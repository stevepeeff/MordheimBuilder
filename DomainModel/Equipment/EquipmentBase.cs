using DomainModel.Equipment.Armour;
using DomainModel.Equipment.Weapons;
using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Equipment.Weapons.Missile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Equipment
{
    public abstract class EquipmentBase : IEquipment
    {
        public EquipmentBase()
        {
            EquipmentProvider.Instance.AddEquipment(this);
        }

        public const int NONE = 0;

        public abstract int Cost { get; }

        public virtual int ArmorSaveModifier { get; }

        public virtual int StrengthModifier { get; }

        public virtual int ToHitModifier { get; }

        public virtual int Strength { get; }

        public virtual Availabilities Availability { get; } = Availabilities.COMMON;

        public string Name { get { return this.GetType().Name; } }

        public virtual int Range { get; }

        public VariabeleCosts VariableCost { get; protected set; }

        public IReadOnlyCollection<CloseCombatWeaponRules> CloseCombatSpecialRules { get { return _CloseCombatRules; } }

        public IReadOnlyCollection<MisseleWeaponRules> MisseleWeaponSpecialRules { get { return _MisseleWeaponRules; } }

        protected List<CloseCombatWeaponRules> _CloseCombatRules = new List<CloseCombatWeaponRules>();

        protected List<MisseleWeaponRules> _MisseleWeaponRules = new List<MisseleWeaponRules>();

        protected List<ArmourRules> _ArmourRules = new List<ArmourRules>();

        public IReadOnlyCollection<ArmourRules> ArmourSpecialRules { get { return _ArmourRules; } }
    }
}