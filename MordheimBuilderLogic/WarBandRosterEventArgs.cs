using DomainModel;
using System;

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