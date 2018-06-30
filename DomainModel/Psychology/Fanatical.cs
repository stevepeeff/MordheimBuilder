using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Psychology
{
    public class Fanatical : IPsychology
    {
        public Afflictions Affliction { get; } = Afflictions.AutomaticallyPassAllLeadershipTests;

        public string Description { get; } = "Self, can never become a warband leader";
    }
}