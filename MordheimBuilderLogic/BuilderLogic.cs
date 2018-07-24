using DomainModel;
using DomainModel.Warbands;
using DomainModel.Warbands.Middenheimers;
using DomainModel.Warbands.Skaven;
using DomainModel.Warbands.WitchHunters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    internal class BuilderLogic : IMordheimBuilderLogic
    {
        private List<IWarBand> _Warbands = new List<IWarBand>()
        {
            new SkavenWarband(),
            new WitchHunterWarband(),
            new MiddenheimerWarband()
         };

        public BuilderLogic()
        {
        }

        public event EventHandler WarBandSelected;

        public IReadOnlyCollection<IWarBand> AvailableWarbands { get { return _Warbands; } }

        public IWarBand CurrentWarband { get; private set; }

        public int StartingCash
        {
            get
            {
                //TODO
                return 500;
            }
        }

        public IWarbandRoster WarbandRoster { get; private set; }

        /// <summary>
        /// Gets or sets the play modus.
        /// </summary>
        /// <value>
        /// The play modus.
        /// </value>
        public Modus PlayModus { get; set; } = Modus.Edit;

        public void SelectWarBand(IWarBand warband)
        {
            CurrentWarband = warband;
            WarbandRoster = new WarBandRoster(CurrentWarband);

            InvokeEvent(WarBandSelected);
        }

        private void InvokeEvent(EventHandler handler)
        {
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}