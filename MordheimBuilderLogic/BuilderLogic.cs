using DomainModel;
using DomainModel.Warbands;
using DomainModel.Warbands.Middenheimers;
using DomainModel.Warbands.Skaven;
using DomainModel.Warbands.WitchHunters;
using MordheimDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    internal class BuilderLogic : IMordheimBuilderLogic
    {
        public BuilderLogic()
        {
        }

        public event EventHandler WarBandSelected;

        public IReadOnlyCollection<IWarBand> AvailableWarbands { get { return WarBandProvider.Instance.WarBands; } }

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

        public void SaveWarband()
        {
            if (WarbandRoster == null) { throw new ArgumentNullException("No warband selected, cannot save"); }
            DalProvider.Instance.Save(WarbandRoster);
        }

        public void LoadWarband(string fileName)
        {
            SelectWarBand(DalProvider.Instance.Load(fileName));
        }
    }
}