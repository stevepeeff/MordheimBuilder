namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class Tentacle : MutationBase
    {
        public Tentacle()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, -1, Applications.CloseCombat, Description));
        }

        public override int Cost { get; } = 35;

        public override string Description { get; } =
            "One of the mutant’s arms ends in a tentacle. He may grapple his opponent in close combat to reduce his attacks by -1, down to a minimum of 1. " +
            "The mutant may decide which attack his opponent loses";
    }
}