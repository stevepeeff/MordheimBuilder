using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Academic
{
    public class AcademicBase : SkillBase, IAcademic
    {
        public override string SkillTypeName { get; } = "Academic";

        public override string Description { get; } = "Not defined";
    }
}