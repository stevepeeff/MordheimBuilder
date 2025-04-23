using DomainModel.Warbands.CultOfThePossessed.Mutations;

namespace MordheimTableTop.Selection
{
    public class MutationViewModel : EquipmentViewModel
    {
        public MutationViewModel(IMutation mutation)
        {
            Mutation = mutation;
        }

        public IMutation Mutation { get; }

        public override string Name => Mutation.Name.SplitCamelCasing();

        public override int Costs => Mutation.Cost;

        public override string Description => Mutation.Description;
    }
}