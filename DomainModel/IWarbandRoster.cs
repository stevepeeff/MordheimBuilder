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
        event EventHandler WarBandChanged;

        string SaveFileName { get; set; }

        /// <summary>Gets a value indicating whether [costs exceed maximum].</summary>
        /// <value>
        ///   <c>true</c> if [costs exceed maximum]; otherwise, <c>false</c>.</value>
        bool CostsExceedMaximum { get; }

        string Name { get; set; }
        int TotalCosts { get; }
        int TotalNumberOfWarriors { get; }
        IWarBand WarBand { get; }
        int WarbandRating { get; }
        IList<IWarrior> Warriors { get; }

        IWarrior AddWarrior(IWarrior warrior);

        void DecreaseHenchmenInGroup(IHenchMen warrior);

        void IncreaseHenchmenInGroup(IHenchMen warrior);

        bool MaximumAllowedAmountOfWarriorReached(IWarrior warrior);

        bool MaximumAllowedAmountOfWarriorsReached();

        void RemoveWarrior(IWarrior warrior);
    }
}