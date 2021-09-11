using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    public class WarBandRosterEventArgs : EventArgs
    {
        public IWarbandRoster WarbandRoster { get; }

        public WarBandRosterEventArgs(IWarbandRoster warbandRoster)
        {
            if (warbandRoster == null) { throw new ArgumentNullException("Warband roster is null"); }
            WarbandRoster = warbandRoster;
        }
    }
}