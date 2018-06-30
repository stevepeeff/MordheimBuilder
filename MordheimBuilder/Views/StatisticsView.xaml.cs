using DomainModel.Skills.Strength;
using DomainModel.Warbands;
using DomainModel.Warbands.WitchHunters;
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
    /// Interaction logic for StatisticsView.xaml
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        private IWarrior _Warrior;

        public IWarrior Warrior
        {
            get { return _Warrior; }
            set
            {
                _Warrior = value;
                InitiateView();
            }
        }

        public StatisticsView()
        {
            InitializeComponent();
        }

        public StatisticsView(IWarrior warrior) : this()
        {
            Warrior = warrior;
        }

        private void InitiateView()
        {
            _1.ViewModel = new StatisticViewModel(Warrior.Movement);
            _2.ViewModel = new StatisticViewModel(Warrior.WeaponSkill);
            _3.ViewModel = new StatisticViewModel(Warrior.BallisticSkill);
            _4.ViewModel = new StatisticViewModel(Warrior.Strength);
            _5.ViewModel = new StatisticViewModel(Warrior.Toughness);
            _6.ViewModel = new StatisticViewModel(Warrior.Wounds);
            _7.ViewModel = new StatisticViewModel(Warrior.Initiative);
            _8.ViewModel = new StatisticViewModel(Warrior.Attacks);
            _9.ViewModel = new StatisticViewModel(Warrior.LeaderShip);
            _10.ViewModel = new StatisticViewModel(Warrior.Save);
        }
    }
}