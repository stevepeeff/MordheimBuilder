namespace DomainModel.Skills.Combat
{
    public class CombatBase : SkillBase, ICombat
    {
        public override string SkillTypeName { get; } = "Combat";

        public override string Description { get; } = "Not defined";
    }
}