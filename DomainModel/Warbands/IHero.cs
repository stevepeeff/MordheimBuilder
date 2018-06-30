using DomainModel.Injuries;
using DomainModel.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public interface IHero : IWarrior
    {
        IReadOnlyCollection<Injury> Injuries { get; }

        void AddInjury(Injury injury);

        void AddSkill(ISkill skill);

        //IInjury
    }
}