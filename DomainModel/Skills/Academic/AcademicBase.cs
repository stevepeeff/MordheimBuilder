namespace DomainModel.Skills.Academic
{
    public class AcademicBase : SkillBase, IAcademic
    {
        public override string SkillTypeName { get; } = "Academic";

        public override string Description { get; } = "Not defined";
    }
}