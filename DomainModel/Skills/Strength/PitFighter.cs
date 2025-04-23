namespace DomainModel.Skills.Strength
{
    public class PitFighter : StrengthBase
    {
        public PitFighter()
        {
            string statisticReason = $"Skill, PitFighter : {Description}";
            _Statistics.Add(new Statistic(Characteristics.Attack, 1, Applications.InsideBuildings, statisticReason));
            _Statistics.Add(new Statistic(Characteristics.WeaponSkill, 1, Applications.InsideBuildings, statisticReason));
        }

        public override string Description { get; } = "The warrior is an expert at fighting in confined areas and adds +1 to his WS and +1 to his Attacks if he is fighting inside buildings or ruins.";
    }
}