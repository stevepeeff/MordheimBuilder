using MordheimBuilder.ViewModels;
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

namespace MordheimBuilder.Views
{
    /// <summary>
    /// Interaction logic for WarbandRosterView.xaml
    /// </summary>
    public partial class WarbandRosterView : UserControl
    {
        public WarbandRosterView()
        {
            InitializeComponent();
            BuilderLogicFactory.Instance.WarbandRoster.WarBandWariorListChanged += WarbandRoster_WarBandWariorListChanged;
            _StackPanelTop.Children.Add(new WarBandOverallView());

            BuildStackPanel();
        }

        private void WarbandRoster_WarBandWariorListChanged(object sender, EventArgs e)
        {
            _StackPanelWarriors.Children.Clear();
            BuildStackPanel();
        }

        private void BuildStackPanel()
        {
            foreach (var warrior in BuilderLogicFactory.Instance.WarbandRoster.Warriors)
            {
                switch (BuilderLogicFactory.Instance.PlayModus)
                {
                    case Modus.Play:
                        {
                            _StackPanelWarriors.Children.Add(new WarriorPlayView(warrior));
                        }
                        break;

                    case Modus.Edit:
                        {
                            _StackPanelWarriors.Children.Add(new WarriorView(warrior));
                        }
                        break;
                }
            }
        }
    }
}