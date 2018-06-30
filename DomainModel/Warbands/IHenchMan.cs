using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public interface IHenchMan : IWarrior
    {
        int NumberOfWarriorsInGroup { get; }

        int? GroupCosts { get; }

        void IncreaseGroupCount();

        void DecreaseGroupCount();
    }
}