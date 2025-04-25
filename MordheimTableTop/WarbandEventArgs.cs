using DomainModel.Warbands;
using System;

namespace MordheimTableTop
{
    internal class WarbandEventArgs : EventArgs
    {
        public IWarBand SelectedWarband { get; }

        public WarbandEventArgs(IWarBand warBand)
        {
            SelectedWarband = warBand;
        }
    }
}