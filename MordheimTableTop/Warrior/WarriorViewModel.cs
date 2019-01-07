using DomainModel.Equipment.Weapons.CloseCombat;
using DomainModel.Warbands;
using MordheimBuilderLogic;
using MordheimTableTop.Selection;
using MordheimTableTop.Warrior.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MordheimTableTop.Warrior
{
    public class WarriorViewModel : ViewModelBase, IDisposable
    {
        public WarriorViewModel(IWarrior warrior)
        {
            Warrior = warrior;
            Equipment = warrior.EquipmentAndMutattionsToViewModel();
            //TODO, move attach only when showing the EQP VM
            Equipment.CollectionChanged += Equipment_CollectionChanged;
            EquipmentSelectionVM = new EquipmentSelectionViewModel(this);
        }

        public event EventHandler EquipmentListChanged;

        public AfflictionViewModel AfflictionVM { get { return new AfflictionViewModel(this); } }

        /// <summary>
        /// Gets the decrease henchmen command.
        /// </summary>
        /// <value>
        /// The decrease henchmen command.
        /// </value>
        public ICommand DecreaseHenchmenCommand => new DecreaseBuyAmount(Warrior);

        public ObservableCollection<EquipmentViewModel> Equipment { get; }

        /// <summary>
        /// Gets the equipment costs.
        /// </summary>
        /// <value>
        /// The equipment costs.
        /// </value>
        public int EquipmentCosts { get { return Warrior.EquipmentCosts; } }

        /// <summary>
        /// Gets the equipment selection vm.
        /// </summary>
        /// <value>
        /// The equipment selection vm.
        /// </value>
        public EquipmentSelectionViewModel EquipmentSelectionVM { get; }

        public int? GroupCosts
        {
            get
            {
                if (Warrior is IHenchMen)
                {
                    IHenchMen henchMen = Warrior as IHenchMen;
                    return (henchMen.GroupCosts);
                }
                else
                {
                    return (Warrior.HireFee + Warrior.EquipmentCosts);
                }
            }
        }

        public int? GroupCount
        {
            get
            {
                if (Warrior is IHenchMen)
                {
                    IHenchMen henchMen = Warrior as IHenchMen;
                    return henchMen.AmountInGroup;
                }

                return null;
            }
        }

        public string GroupCountFormatted
        {
            get
            {
                if (Warrior is IHenchMen)
                {
                    return $"({GroupCount})";
                }
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the increase henchmen command.
        /// </summary>
        /// <value>
        /// The increase henchmen command.
        /// </value>
        public ICommand IncreaseHenchmenCommand => new IncreaseBuyAmount(Warrior);

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        public ICommand RemoveWarriorCommand => new RelayCommand(x => BuilderLogicFactory.Instance.WarbandRoster.RemoveWarrior(Warrior));

        public ICommand ShowEquipmentSelectionCommand => new RelayCommand(x => ShowEquipmentSelection());

        /// <summary>
        /// Gets the show increase decrease buttons.
        /// </summary>
        /// <value>
        /// The show increase decrease buttons.
        /// </value>
        public Visibility ShowIncreaseDecreaseButtons
        {
            get
            {
                if (Warrior is IHenchMen) { return Visibility.Visible; }
                return Visibility.Collapsed;
            }
        }

        public StatisticsViewModel StatisticsVM { get { return new StatisticsViewModel(Warrior); } }

        public IWarrior Warrior { get; }

        public string WarriorTypeName { get { return Warrior.TypeName.SplitCamelCasing(); } }

        public void Dispose()
        {
            Equipment.CollectionChanged -= Equipment_CollectionChanged;
        }

        private void Equipment_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifiyPropertyChangedEvent(nameof(GroupCosts));
            NotifiyPropertyChangedEvent(nameof(EquipmentCosts));

            if (EquipmentListChanged != null)
            {
                EquipmentListChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private void ShowEquipmentSelection()
        {
            Window window = new Window()
            {
                Content = new EquipmentSelectionView(EquipmentSelectionVM)
            };
            window.Show();
        }
    }
}