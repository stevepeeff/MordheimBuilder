namespace DomainModel.Skills.Speed
{
    public class SpeedBase : SkillBase, ISpeed
    {
        public override string SkillTypeName { get; } = "Speed";

        public override string Description { get; } = "Not defined";
    }
}