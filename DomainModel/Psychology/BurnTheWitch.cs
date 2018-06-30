using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class BurnTheWitch : IPsychology
    {
        public Afflictions Affliction { get; } = Afflictions.Fear;

        public string Description { get; } = "All models who can cast spells";
    }
}