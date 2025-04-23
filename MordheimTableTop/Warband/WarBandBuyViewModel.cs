using DomainModel.Warbands;
using MordheimBuilderLogic;
using MordheimTableTop.Warrior;
using System;
using System.Collections.ObjectModel;

namespace MordheimTableTop.Warband
{
    internal class WarBandBuyViewModel : ViewModelBase
    {
        public ObservableCollection<WarriorBuyViewModel> Warriors { get; } = new ObservableCollection<WarriorBuyViewModel>();

        public WarBandBuyViewModel()
        {
            foreach (var item in Warband.Heroes)
            {
                Warriors.Add(new WarriorBuyViewModel(item));
            }
            foreach (var item in Warband.HenchMen)
            {
                Warriors.Add(new WarriorBuyViewModel(item));
            }

            if (Warband.RacialAdvantages != null)
            {
                Advantages = Warband.RacialAdvantages.Description;
            }

            if (String.IsNullOrEmpty(Advantages)) { Advantages = "-"; }
        }

        public string Advantages { get; }

        public IWarBand Warband { get; } = BuilderLogicFactory.Instance.WarbandRoster.WarBand;

        public string WarbandName => Warband.WarBandName.SplitCamelCasing();
    }
}