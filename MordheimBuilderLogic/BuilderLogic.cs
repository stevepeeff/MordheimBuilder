using DomainModel;
using DomainModel.Warbands;

using System;
using System.Collections.Generic;

namespace MordheimBuilderLogic
{
    internal class BuilderLogic : IMordheimBuilderLogic
    {
        private Modus _PlayModus = Modus.Edit;

        public BuilderLogic()
        {
        }

        public event EventHandler PlayModusChanges;

        public event EventHandler<WarBandRosterEventArgs> WarbandRosterChanged;

        public IReadOnlyCollection<IWarBand> AvailableWarbands
        { get { return WarBandProvider.Instance.WarBands; } }

        public IWarBand CurrentWarband { get; private set; }

        /// <summary>
        /// Gets or sets the play modus.
        /// </summary>
        /// <value>
        /// The play modus.
        /// </value>
        public Modus PlayModus
        {
            get
            {
                return _PlayModus;
            }
            set
            {
                _PlayModus = value;
                InvokeEvent(PlayModusChanges);
            }
        }

        public int StartingCash
        {
            get
            {
                //TODO
                return 500;
            }
        }

        private IWarbandRoster _WarbandRoster;

        public IWarbandRoster WarbandRoster
        {
            get
            {
                return _WarbandRoster;
            }
            private set
            {
                _WarbandRoster = value;
                if (WarbandRosterChanged != null)
                {
                    WarbandRosterChanged.Invoke(this, new WarBandRosterEventArgs(_WarbandRoster));
                }
            }
        }

        public void SelectWarBand(IWarBand warband)
        {
            CurrentWarband = warband;
            WarbandRoster = new WarBandRoster(CurrentWarband);
        }

        public void SelectWarBand(string warbandName)
        {
            SelectWarBand(WarBandProvider.Instance.GetWarband(warbandName));
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