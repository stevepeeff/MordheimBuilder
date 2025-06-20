﻿using DomainModel.Injuries;
using DomainModel.Skills;
using System.Collections.Generic;

namespace DomainModel.Warbands
{
    /// <summary>
    /// A hero has more abilities the a warrior
    /// </summary>
    /// <seealso cref="DomainModel.Warbands.IWarrior" />
    public interface IHero : IWarrior
    {
        /// <summary>
        /// Gets the injuries.
        /// </summary>
        /// <value>
        /// The injuries.
        /// </value>
        IReadOnlyCollection<Injury> Injuries { get; }

        /// <summary>
        /// Gets the skills.
        /// </summary>
        /// <value>
        /// The skills.
        /// </value>
        IReadOnlyCollection<ISkill> Skills { get; }

        /// <summary>
        /// Adds the injury.
        /// </summary>
        /// <param name="injury">The injury.</param>
        void AddInjury(Injury injury);

        /// <summary>
        /// Adds the skill.
        /// </summary>
        /// <param name="skill">The skill.</param>
        void AddSkill(ISkill skill);

        /// <summary>
        /// Adds the skill.
        /// </summary>
        /// <param name="skillName">Name of the skill.</param>
        void AddSkill(string skillName);
    }
}