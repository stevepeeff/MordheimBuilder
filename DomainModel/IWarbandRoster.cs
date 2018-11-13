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

        string Name { get; set; }

        IWarBand WarBand { get; }

        int TotalNumberOfWarriors { get; }

        int TotalCosts { get; }

        int WarbandRating { get; }

        IWarrior AddWarrior(IWarrior warrior);

        void RemoveWarrior(IWarrior warrior);

        void IncreaseHenchmenInGroup(IHenchMen warrior);

        void DecreaseHenchmenInGroup(IHenchMen warrior);

        bool MaximumAllowedAmountOfWarriorReached(IWarrior warrior);

        bool MaximumAllowedAmountOfWarriorsReached();

        event EventHandler WarBandChanged;
    }
}