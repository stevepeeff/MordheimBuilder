namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Hideous : MutationBase
    {
        public Hideous()
        {
        }

        public override int Cost { get; } = 40;

        public override string Description { get; } = "The mutant causes fears";
    }
}