namespace DomainModel.RacialAdvantages
{
    public class ReiklandAdvantage : AdvantagesBase
    {
        public ReiklandAdvantage()
        {
            _Statistics.Add(new Statistic(Characteristics.BallisticSkill, 1, Applications.Shooting, $"Reikland RacialAdvantage : {Description}"));
        }

        public override string Description { get; } = "All marksmen have an increased ballistic skill";
    }
}