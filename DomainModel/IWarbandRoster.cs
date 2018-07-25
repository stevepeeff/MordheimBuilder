using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IWarbandRoster
    {
        IList<IWarrior> Warriors { get; }

        IWarBand WarBand { get; }

        event EventHandler WarBandWariorListChanged;

        int TotalNumberOfWarriors { get; }

        int TotalCosts { get; }

        int WarbandRating { get; }

        void AddWarrior(IWarrior warrior);

        void RemoveWarrior(IWarrior warrior);

        void IncreaseHenchmenInGroup(IHenchMan warrior);

        void DecreaseHenchmenInGroup(IHenchMan warrior);

        bool MaximumAllowedAmountOfWarriorReached(IWarrior warrior);

        bool MaximumAllowedAmountOfWarriorsReached();

        event EventHandler WarBandChanged;
    }
}