using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Warbands
{
    public class WarBandProvider
    {
        public static WarBandProvider Instance { get; } = new WarBandProvider();

        private WarBandProvider()
        {
        }
    }
}