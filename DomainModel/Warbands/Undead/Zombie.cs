using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;

namespace DomainModel.Warbands.Undead
{
    internal class Zombie : WarriorBase, IHenchMen
    {
        public Zombie()
        {
            Movement.BaseValue = 4;
            WeaponSkill.BaseValue = 2;
            BallisticSkill.BaseValue = 0;

            Initiative.BaseValue = 1;
            Attacks.BaseValue = 1;
            LeaderShip.BaseValue = 5;

            AddAffliction(new Fear());
            AddAffliction(new MayNotRun());
            AddAffliction(new ImmuneToPsychology());
            AddAffliction(new ImmuneToPoison());
            AddAffliction(new NoPain());
            AddAffliction(new NoBrain());
        }

        /// <summary>
        /// Gets the maximum experience.
        /// Zombies never gain experience
        /// </summary>
        /// <value>
        /// The maximum experience.
        /// </value>
        public override int MaximumExperience => 0;

        public override int HireFee => 15;

        public override int MaximumAllowedInWarBand => INFINITE;

        public override IWarrior GetANewInstance()
        {
            return new Zombie();
        }
    }
}