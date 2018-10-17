using DomainModel.Warbands.BaseClasses;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public abstract class MutantBase : HeroBase, IMutant
    {
        private List<IMutation> _Mutations = new List<IMutation>();

        public IReadOnlyCollection<IMutation> Mutations => _Mutations;

        public void AddMutation(IMutation mutation)
        {
            if (_Mutations.Any(x => x.GetType().Equals(mutation.GetType())) == false)
            {
                _Mutations.Add(mutation);
            }
        }

        protected override void CalculateCharacteristicsModifiers()
        {
            base.CalculateCharacteristicsModifiers();

            foreach (IMutation mutation in Mutations)
            {
                foreach (var statistic in mutation.Statistics)
                {
                    _CharacteristicModifiers.Add(new CharacteristicModifier(statistic));
                }
            }
        }

        public override int MaximumCloseCombatWeapons
        {
            get
            {
                int mutatantCalucation = base.MaximumCloseCombatWeapons;

                if (_Mutations.Any(x => x.GetType().Equals(typeof(ExtraArm))))
                {
                    mutatantCalucation += 1;
                }

                return mutatantCalucation;
            }
        }

        public void RemoveMutation(IMutation mutation)
        {
            _Mutations.Remove(mutation);
        }
    }
}