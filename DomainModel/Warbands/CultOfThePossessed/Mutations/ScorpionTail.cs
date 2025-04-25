namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class ScorpionTail : MutationBase
    {
        public ScorpionTail()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.CloseCombat, Description));
            //  _Statistics.Add(new Statistic(Characteristics.Strength, 1, Applications.CloseCombat, "Only for t attack mad wit tis arm"));
        }

        public override int Cost { get; } = 40;

        public override string Description { get; } = "The mutant has a long barbed tail with a venomed tip, allowing him to make an extra Strength 5 attack in each hand-to-hand combat phase.If the model hit by the tail is immune to poison, the Strength of the hit is reduced to 2.";
    }
}