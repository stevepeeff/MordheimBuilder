using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimTableTop
{
    internal class WarbandEventArgs : EventArgs
    {
        private IWarBand SelectedWarband { get; }

        public WarbandEventArgs(IWarBand warBand)
        {
            SelectedWarband = warBand;
        }
    }
}