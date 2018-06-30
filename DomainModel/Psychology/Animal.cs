using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class Animal : IPsychology
    {
        public Afflictions Affliction { get; } = Afflictions.NeverGainExperience;

        public string Description { get; } = "Can't teach a dog a new trick";
    }
}