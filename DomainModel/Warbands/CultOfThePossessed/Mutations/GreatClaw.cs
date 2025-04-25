namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class GreatClaw : MutationBase
    {
        public GreatClaw()
        {
            _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.CloseCombat, Description));
            _Statistics.Add(new Statistic(Characteristics.Strength, 1, Applications.CloseCombat, "Only for attack made with this arm"));
        }

        public override int Cost { get; } = 50;

        public override string Description { get; } = "The mutant has an extra arm, giving him +1 attack and strength bonus";
    }
}