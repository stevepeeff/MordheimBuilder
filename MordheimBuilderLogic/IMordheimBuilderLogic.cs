using DomainModel;
using DomainModel.Warbands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilderLogic
{
    public enum Modus
    {
        Play,
        Edit
    }

    public interface IMordheimBuilderLogic
    {
        IReadOnlyCollection<IWarBand> AvailableWarbands { get; }

        void SelectWarBand(IWarBand warband);

        void SelectWarBand(string warbandName);

        IWarBand CurrentWarband { get; }

        IWarbandRoster WarbandRoster { get; }

        event EventHandler WarBandSelected;

        int StartingCash { get; }

        Modus PlayModus { get; set; }

        // void SaveWarband();

        // void LoadWarband(string fileName);
    }
}