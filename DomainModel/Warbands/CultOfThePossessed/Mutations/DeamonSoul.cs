namespace DomainModel.Warbands.CultOfThePossessed.Mutations
{
    public class DeamonSoul : MutationBase
    {
        public DeamonSoul()
        {
            _Statistics.Add(new Statistic(Characteristics.Save, 4, Applications.MagicSpellsAndPrayers, Description));
        }

        public override int Cost { get; } = 20;

        public override string Description { get; } = "A Daemon lives within the mutant’s soul. This gives him a 4+ save against the effects of spells or prayers";
    }
}