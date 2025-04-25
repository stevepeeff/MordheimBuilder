namespace DomainModel.Skills.Strength
{
    public class StrengthBase : SkillBase, IStrength
    {
        public override string SkillTypeName { get; } = "Strength";

        public override string Description { get; } = "Not defined";
    }
}