using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class SkillViewModel
    {
        public SkillViewModel(ISkill skill)
        {
            School = skill.SkillTypeName;
            Name = skill.SkillName();
            Description = skill.Description;
        }

        public string School { get; }

        public string Name { get; }

        public string Description { get; }
    }
}