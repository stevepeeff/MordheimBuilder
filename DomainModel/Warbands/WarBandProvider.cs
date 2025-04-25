using DomainModel.Warbands.CultOfThePossessed;
using DomainModel.Warbands.Marienburg;
using DomainModel.Warbands.Middenheim;
using DomainModel.Warbands.Reikland;
using DomainModel.Warbands.SistersOfSigmar;
using DomainModel.Warbands.Skaven;
using DomainModel.Warbands.Undead;
using DomainModel.Warbands.WitchHunters;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Warbands
{
    public class WarBandProvider
    {
        public static WarBandProvider Instance { get; } = new WarBandProvider();

        public IReadOnlyCollection<IWarBand> WarBands
        { get { return _Warbands; } }

        private List<IWarBand> _Warbands = new List<IWarBand>();

        public IWarBand GetWarband(string name)
        {
            return WarBands.Single(x => x.WarBandName.Equals(name));
        }

        private WarBandProvider()
        {
            _Warbands.Add(new MarienburgWarband());
            _Warbands.Add(new MiddenheimWarband());
            _Warbands.Add(new ReiklandWarband());
            _Warbands.Add(new CultOfThePossessedWarband());
            _Warbands.Add(new SkavenWarband());
            _Warbands.Add(new SistersOfSigmarWarband());
            _Warbands.Add(new UndeadWarband());
            _Warbands.Add(new WitchHuntersWarband());
        }
    }
}