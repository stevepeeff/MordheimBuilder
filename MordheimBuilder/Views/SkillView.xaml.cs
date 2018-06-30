using System.Windows.Controls;

namespace MordheimBuilder.Views
{
    /// <summary>
    /// Interaction logic for SkillView.xaml
    /// </summary>
    public partial class SkillView : UserControl
    {
        public SkillView()
        {
            InitializeComponent();
        }

        public SkillView(WarriorViewModel warriorViewModel) : this()
        {
            this.DataContext = warriorViewModel;
        }
    }
}