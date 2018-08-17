﻿using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
using MordheimBuilder.Commands;
using MordheimBuilder.ViewModels;
using MordheimBuilder.Views;
using MordheimBuilder.Views.ModusView;
using MordheimBuilderLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MordheimBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //THIS CODE IS BROKEN
            //this.DataContext = new WarBandOverallViewModel();

            //TESTING..
            LoadWarBand();
            this.DataContext = this;
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <value>
        /// The save command.
        /// </value>
        public ICommand SaveCommand { get; } = new SaveWarband();

        /// <summary>
        /// Gets the load command.
        /// </summary>
        /// <value>
        /// The load command.
        /// </value>
        public ICommand LoadCommand { get; } = new LoadWarband();

        /// <summary>
        /// Gets the edit mode command.
        /// </summary>
        /// <value>
        /// The edit mode command.
        /// </value>
        public ICommand EditModeCommand => new EditMode(this);

        /// <summary>
        /// Gets the play mode command.
        /// </summary>
        /// <value>
        /// The play mode command.
        /// </value>
        public ICommand PlayModeCommand => new PlayMode(this);

        //TODO Move all event handlers to ViewModel

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dlg = new PrintDialog();

            if (dlg.ShowDialog().GetValueOrDefault() == true)
            {
                dlg.PrintVisual(this, Title);
            }
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
        }

        private void MenuItem_Load_Click(object sender, RoutedEventArgs e)
        {
            LoadWarBand();
        }

        private void LoadWarBand()
        {
            //TEST CODE
            BuilderLogicFactory.Instance.SelectWarBand(BuilderLogicFactory.Instance.AvailableWarbands.ElementAt(0));

            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(BuilderLogicFactory.Instance.CurrentWarband.Heroes.ElementAt(0));
            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(BuilderLogicFactory.Instance.CurrentWarband.Heroes.ElementAt(1));
            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(BuilderLogicFactory.Instance.CurrentWarband.HenchMen.ElementAt(0));
            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(BuilderLogicFactory.Instance.CurrentWarband.HenchMen.ElementAt(1));
            BuilderLogicFactory.Instance.WarbandRoster.AddWarrior(BuilderLogicFactory.Instance.CurrentWarband.HenchMen.ElementAt(2));

            EditModeCommand.Execute(null);
            //PlayModeCommand.Execute(null);
        }
    }
}