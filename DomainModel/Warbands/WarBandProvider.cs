using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Warbands.Middenheimers;
using DomainModel.Warbands.Skaven;
using DomainModel.Warbands.WitchHunters;

namespace DomainModel.Warbands
{
    public class WarBandProvider
    {
        public static WarBandProvider Instance { get; } = new WarBandProvider();

        public IReadOnlyCollection<IWarBand> WarBands { get { return _Warbands; } }

        private List<IWarBand> _Warbands = new List<IWarBand>();

        public IWarBand GetWarband(string name)
        {
            return WarBands.Single(x => x.WarBandName.Equals(name));
        }

        private WarBandProvider()
        {
            //  DomainModel.Warbands.WitchHunters.WitchHunters witchHunters = new
            _Warbands.Add(new WitchHuntersWarband());
            _Warbands.Add(new SkavenWarband());
            _Warbands.Add(new MiddenheimWarband());
        }
    }
}