using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills
{
    public abstract class SkillBase : ISkill
    {
        protected List<Statistic> _Statistics = new List<Statistic>();

        public IReadOnlyCollection<Statistic> Statistics { get { return _Statistics; } }

        public abstract string SkillTypeName { get; }

        public string SkillName => SkillProviderTools.SkillName(this);

        public abstract string Description { get; }
    }
}