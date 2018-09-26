using DomainModel.Equipment;
using DomainModel.Equipment.Weapons;
using DomainModel.Psychology;
using DomainModel.RacialAdvantages;
using DomainModel.Skills;
using DomainModel.WarriorStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    /// <summary>
    /// All specifications of a Warrior
    /// </summary>
    public interface IWarrior
    {
        /// <summary>
        /// Occurs when [properties changed].
        /// </summary>
        event EventHandler PropertiesChanged;

        /// <summary>
        /// Gets the afflictions.
        /// </summary>
        /// <value>
        /// The afflictions.
        /// </value>
        IReadOnlyCollection<IPsychology> Afflictions { get; }

        /// <summary>
        /// Gets the allowed equipment.
        /// </summary>
        /// <value>
        /// The allowed equipment.
        /// </value>
        IReadOnlyCollection<IEquipment> AllowedEquipment { get; }

        /// <summary>
        /// Gets the allowed skills.
        /// </summary>
        /// <value>
        /// The allowed skills.
        /// </value>
        IReadOnlyCollection<ISkill> AllowedSkills { get; }

        /// <summary>
        /// Gets the attacks.
        /// </summary>
        /// <value>
        /// The attacks.
        /// </value>
        Characteristic Attacks { get; }

        /// <summary>
        /// Gets the ballistic skill.
        /// </summary>
        /// <value>
        /// The ballistic skill.
        /// </value>
        Characteristic BallisticSkill { get; }

        /// <summary>
        /// Gets the current experience.
        /// </summary>
        /// <value>
        /// The current experience.
        /// </value>
        int CurrentExperience { get; }

        /// <summary>
        /// Gets the equipped weapons.
        /// TODO a second hand weapon in CC add +1 attack, if this weapon is different from the one in the other hand
        /// (E.g. Dagger and Sword) roll separate for the added attack
        /// </summary>
        /// <value>
        /// The equipped weapons.
        /// </value>
        IReadOnlyCollection<IEquipment> Equipment { get; }

        /// <summary>
        /// Gets the equipment costs.
        /// </summary>
        /// <value>
        /// The equipment costs.
        /// </value>
        int EquipmentCosts { get; }

        /// <summary>
        /// Gets the hire fee.
        /// </summary>
        /// <value>
        /// The hire fee.
        /// </value>
        int HireFee { get; }

        /// <summary>
        /// Gets the initiative.
        /// </summary>
        /// <value>
        /// The initiative.
        /// </value>
        Characteristic Initiative { get; }

        /// <summary>
        /// Gets the leader ship.
        /// </summary>
        /// <value>
        /// The leader ship.
        /// </value>
        Characteristic LeaderShip { get; }

        /// <summary>
        /// Gets the maximum allowed in war band.
        /// </summary>
        /// <value>
        /// The maximum allowed in war band.
        /// </value>
        int MaximumAllowedInWarBand { get; }

        /// <summary>
        /// Gets the maximum experience.
        /// </summary>
        /// <value>
        /// The maximum experience.
        /// </value>
        int MaximumExperience { get; }

        /// <summary>
        /// Gets the movement.
        /// </summary>
        /// <value>
        /// The movement.
        /// </value>
        Characteristic Movement { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets the save.
        /// </summary>
        /// <value>
        /// The save.
        /// </value>
        Characteristic Save { get; }

        /// <summary>
        /// Gets the strength.
        /// </summary>
        /// <value>
        /// The strength.
        /// </value>
        Characteristic Strength { get; }

        /// <summary>
        /// Gets the toughness.
        /// </summary>
        /// <value>
        /// The toughness.
        /// </value>
        Characteristic Toughness { get; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        string TypeName { get; }

        /// <summary>
        /// Gets the weapon skill.
        /// </summary>
        /// <value>
        /// The weapon skill.
        /// </value>
        Characteristic WeaponSkill { get; }

        /// <summary>
        /// Gets the warrior status.
        /// </summary>
        /// <value>
        /// The warrior status.
        /// </value>
        IWarriorStatus WarriorStatus { get; }

        /// <summary>
        /// Changes the status.
        /// </summary>
        /// <param name="warriorStatus">The warrior status.</param>
        void ChangeStatus(IWarriorStatus warriorStatus);

        /// <summary>
        /// Gets the wounds.
        /// </summary>
        /// <value>
        /// The wounds.
        /// </value>
        Characteristic Wounds { get; }

        /// <summary>
        /// Adds the affliction.
        /// </summary>
        /// <param name="affliction">The affliction.</param>
        void AddAffliction(IPsychology affliction);

        /// <summary>
        /// Adds the equipment.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        void AddEquipment(IEquipment equipment);

        /// <summary>
        /// Adds the equipment.
        /// </summary>
        /// <param name="name">The name.</param>
        void AddEquipment(string name);

        /// <summary>
        /// Amounts the type of the of this.
        /// </summary>
        /// <param name="warrior">The warrior.</param>
        /// <returns></returns>
        int AmountOfThisType(IWarrior warrior);

        /// <summary>
        /// Gets an instance. Use when adding a warrior to a Roster
        /// </summary>
        /// <returns></returns>
        IWarrior GetAnInstance();

        /// <summary>
        /// Determines whether [is level up] [the specified experience value].
        /// </summary>
        /// <param name="experienceValue">The experience value.</param>
        /// <returns>
        ///   <c>true</c> if [is level up] [the specified experience value]; otherwise, <c>false</c>.
        /// </returns>
        bool IsLevelUp(int experienceValue);

        /// <summary>
        /// Removes the equipment.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        void RemoveEquipment(IEquipment equipment);
    }
}