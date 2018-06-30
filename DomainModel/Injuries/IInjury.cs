using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Injuries
{
    public enum Durations
    {
        OneGame,
        Permanent,
        Once,
    }

    public interface Injury
    {
        int RollFrom { get; }

        int RollTill { get; }

        string Name { get; }

        string Description { get; }

        //E.g. miss next game
        // Arm amputated Only 1 single handed weapon

        Statistic Result { get; }

        Durations Duration { get; }
    }
}