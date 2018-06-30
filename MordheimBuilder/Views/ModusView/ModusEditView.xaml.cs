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

namespace MordheimBuilder.Views.ModusView
{
    /// <summary>
    /// Interaction logic for ModusEditView.xaml
    /// </summary>
    public partial class ModusEditView : UserControl
    {
        public ModusEditView()
        {
            InitializeComponent();

            BuilderLogicFactory.Instance.WarBandSelected += Instance_WarBandSelected;

            _StackPanelLeft.Children.Add(new WarBandInformation());
            _StackPanelRight.Children.Add(new WarbandRosterView());

            foreach (var hero in BuilderLogicFactory.Instance.CurrentWarband.Heroes)
            {
                _StackPanelLeft.Children.Add(new WarriorSimpleView(hero));
            }
            foreach (var henchman in BuilderLogicFactory.Instance.CurrentWarband.HenchMen)
            {
                _StackPanelLeft.Children.Add(new WarriorSimpleView(henchman));
            }
        }

        private void Instance_WarBandSelected(object sender, EventArgs e)
        {
            _StackPanelLeft.Children.Clear();
            _StackPanelLeft.Children.Add(new WarBandInformation());

            foreach (var hero in BuilderLogicFactory.Instance.CurrentWarband.Heroes)
            {
                _StackPanelLeft.Children.Add(new WarriorSimpleView(hero));
            }
            foreach (var henchman in BuilderLogicFactory.Instance.CurrentWarband.HenchMen)
            {
                _StackPanelLeft.Children.Add(new WarriorSimpleView(henchman));
            }

            _StackPanelRight.Children.Clear();
            _StackPanelRight.Children.Add(new WarbandRosterView());
        }
    }
}