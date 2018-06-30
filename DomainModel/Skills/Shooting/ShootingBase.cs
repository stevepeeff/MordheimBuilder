using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Skills.Shooting
{
    public class ShootingBase : SkillBase, IShooting
    {
        public override string Name { get; } = "Shooting";

        public override string Description { get; } = "Not defined";
    }
}