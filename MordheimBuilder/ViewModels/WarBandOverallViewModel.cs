﻿using DomainModel;
using DomainModel.Warbands;
using MordheimBuilder.Commands;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MordheimBuilder.ViewModels
{
    public class WarBandOverallViewModel : ViewModelBase
    {
        private IWarBand m_Warband;

        public WarBandOverallViewModel()
        {
            Warbands = new List<WarBandOverallViewModel>();
            foreach (var item in BuilderLogicFactory.Instance.AvailableWarbands)
            {
                Warbands.Add(new WarBandOverallViewModel(item));
            }
        }

        private WarBandOverallViewModel(IWarBand warband)
        {
            m_Warband = warband;
        }

        public int MaximumWarriors => m_Warband.MaximumNumberOfWarriors;

        public string Description => m_Warband.Description;

        public int MaximumWarriorOfNumbers => m_Warband.MaximumNumberOfWarriors;

        public string Name => m_Warband.WarBandName;

        /// <summary>
        /// Gets or sets the selected warband.
        /// </summary>
        /// <value>
        /// The selected warband.
        /// </value>
        public WarBandOverallViewModel SelectedWarband { get; set; }

        public int StartingCash => m_Warband.StartingCash;

        /// <summary>
        /// Gets the warbands.
        /// </summary>
        /// <value>
        /// The warbands.
        /// </value>
        public IList<WarBandOverallViewModel> Warbands { get; }
    }
}