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
    /// Interaction logic for WarbandPickerView.xaml
    /// </summary>
    public partial class WarbandPickerView : UserControl, IProperViewToViewModel
    {
        public WarbandPickerView()
        {
            InitializeComponent();
            WarBandOverallViewModel viewModel = (WarBandOverallViewModel)DataContext;
            viewModel.ViewInterface = this;
        }

        private bool closCalld = false;

        public void Close()
        {
            if (!closCalld)
            {
                //closCalld = true;
                this.Close();
            }
        }
    }
}