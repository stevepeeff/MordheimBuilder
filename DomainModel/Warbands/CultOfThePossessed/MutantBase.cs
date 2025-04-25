using DomainModel.Psychology;
using DomainModel.Warbands.BaseClasses;
using DomainModel.Warbands.CultOfThePossessed.Mutations;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Warbands.CultOfThePossessed
{
    public abstract class MutantBase : HeroBase, IMutant
    {
        private List<IMutation> _Mutations = new List<IMutation>();

        public MutantBase()
        {
            AddAffliction(new Mutation());
        }

        public override int EquipmentCosts
        {
            get
            {
                int totalCosts = base.EquipmentCosts;

                foreach (var item in _Mutations)
                {
                    totalCosts += item.Cost;
                }
                return totalCosts;
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

        public IReadOnlyCollection<IMutation> Mutations => _Mutations;

        public override bool AddMutation(IMutation mutation)
        {
            if (_Mutations.Any(x => x.GetType().Equals(mutation.GetType())) == false)
            {
                _Mutations.Add(mutation);
                TriggerCharacteristicChanged();
                return true;
            }
            return false;
        }

        public void AddMutations(List<string> mutations)
        {
            foreach (string mutation in mutations)
            {
                _Mutations.Add(MutationsProvider.Instance.Mutations.Single(x => x.Name.Equals(mutation)));
            }
        }

        public override void RemoveMutation(IMutation mutation)
        {
            _Mutations.Remove(mutation);
            TriggerCharacteristicChanged();
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
    }
}