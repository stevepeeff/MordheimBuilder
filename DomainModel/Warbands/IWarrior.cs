using DomainModel.Equipment;
using DomainModel.Equipment.Weapons;
using DomainModel.Psychology;
using DomainModel.RacialAdvantages;
using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public interface IWarrior
    {
        int HireFee { get; }

        int MaximumAmountInWarBand { get; }

        IReadOnlyCollection<ISkill> Skills { get; }

        IReadOnlyCollection<ISkill> AllowedSkills { get; }

        event EventHandler PropertiesChanged;

        /// <summary>
        /// Gets the equipped weapons.
        /// TODO a second hand weapon in CC add +1 attack, if this weapon is different from the one in the other hand
        /// (E.g. Dagger and Sword) roll separate for the added attack
        /// </summary>
        /// <value>
        /// The equipped weapons.
        /// </value>
        IReadOnlyCollection<IEquipment> Equipment { get; }

        IReadOnlyCollection<IEquipment> AllowedEquipment { get; }

        IReadOnlyCollection<IPsychology> Afflictions { get; }

        int NumberOffWarriorsOfThisType(IWarrior warrior);

        /// <summary>
        /// Gets the maximum experience.
        /// </summary>
        /// <value>
        /// The maximum experience.
        /// </value>
        int MaximumExperience { get; }

        bool ExperienceIsLevelUp(int experienceValue);

        int CurrentExperience { get; }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        /// <returns></returns>
        IWarrior GetAnInstance();

        bool AreEqual(IWarrior warior);

        /// <summary>
        /// Gets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        DateTime? CreationDate { get; }

        /// <summary>
        /// Gets the equipment costs.
        /// </summary>
        /// <value>
        /// The equipment costs.
        /// </value>
        int EquipmentCosts { get; }

        void RemoveEquipment(IEquipment equipment);

        void AddEquipment(IEquipment equipment);

        /// <summary>
        /// Adds the affliction.
        /// </summary>
        /// <param name="affliction">The affliction.</param>
        void AddAffliction(IPsychology affliction);

        Characteristic Strength { get; }
        Characteristic Initiative { get; }
        Characteristic Movement { get; }
        Characteristic WeaponSkill { get; }
        Characteristic BallisticSkill { get; }
        Characteristic Toughness { get; }
        Characteristic Wounds { get; }
        Characteristic Attacks { get; }
        Characteristic LeaderShip { get; }
        Characteristic Save { get; }

        string Name { get; set; }

        string TypeName { get; }
    }
}