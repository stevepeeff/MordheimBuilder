using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class SkillViewModelSimple
    {
        public SkillViewModelSimple(ISkill skill)
        {
            Name = skill.SkillName().SplitCamelCasing();
        }

        public string Name { get; }
    }
}