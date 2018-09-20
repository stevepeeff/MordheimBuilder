using DomainModel.Equipment;
using DomainModel.Skills;
using DomainModel.Warbands;
using MordheimBuilder.Commands;
using MordheimBuilder.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

/// <summary>
///
/// </summary>
namespace MordheimBuilder
{
    public class WarriorViewModel : ViewModelBase
    {
        public WarriorViewModel(IWarrior warrior)
        {
            if (warrior == null) { throw new ArgumentNullException("Warrior is null"); }
            Warrior = warrior;
            Warrior.PropertiesChanged += Warrior_PropertiesChanged;
            ShowWeaponsPickerCommand = new ShowWeaponsPicker(this);
            BuyWarriorCommand = new BuyWarrior(this);
            RemoveWarriorCommand = new RemoveWarrior(this);
            IncreaseWarriorBuyAmountCommand = new IncreaseBuyAmount(this);
            DecreaseWarriorBuyAmountCommand = new DecreaseBuyAmount(this);
            ShowSkillSelectorCommand = new ShowSkillSelector(this);

            foreach (IEquipment item in warrior.Equipment)
            {
                EquippedWeapons.Add(new EquipmentSummaryViewModel(item));
            }

            foreach (var item in warrior.AllowedSkills)
            {
                //if (!warrior.Skills.Contains(item))
                //{
                AllowedSkills.Add(new SkillViewModel(item));
                //}
            }

            IWizard wizard = warrior as IWizard;
            if (wizard != null)
            {
                foreach (var item in wizard.DrawnSpells)
                {
                    Spells.Add(new SpellViewModel(item));
                }
            }

            IHero hero = warrior as IHero;
            if (hero != null)
            {
                foreach (var item in hero.Injuries)
                {
                    InjuryViewModel injuryModel = new InjuryViewModel(item);

                    Injuries.Add(injuryModel);
                    InjuriesSimple.Add(injuryModel);
                }

                foreach (var item in hero.Skills)
                {
                    Skills.Add(new SkillViewModel(item));
                    SkillsSimple.Add(new SkillViewModelSimple(item));
                }
            }
        }

        public string SpecialRules
        {
            get
            {
                string retval = " -";

                bool appendComma = false;
                foreach (var item in Warrior.Afflictions)
                {
                    if (appendComma == false)
                    {
                        retval = $" {item.Name.SplitCamelCasing()}";
                    }
                    else
                    {
                        retval += $" ,{item.Name.SplitCamelCasing()}";
                    }

                    appendComma = true;
                }

                return retval;
            }
        }

        public string SkillSummary
        {
            get
            {
                string skillList = String.Empty;

                foreach (string skillName in Warrior.AllowedSkills.DistinctNames())
                {
                    string formatttedSkillName = skillName.Remove(0,1).SplitCamelCasing();

                    if (String.IsNullOrEmpty(skillList))
                    {
                        skillList = $" {formatttedSkillName}"; ;
                    }
                    else
                    {
                        skillList += $" ,{formatttedSkillName}";
                    }
                }

                if (String.IsNullOrEmpty(skillList)) { skillList = "-"; }
                return skillList;
            }
        }

        /// <summary>
        /// Gets the equipped weapons.
        /// Dot NOT ever remove or add to this list directly, use the appropriate function to ensure the domain model is updated
        /// </summary>
        /// <value>
        /// The equipped weapons.
        /// </value>
        public ObservableCollection<EquipmentSummaryViewModel> EquippedWeapons { get; } = new ObservableCollection<EquipmentSummaryViewModel>();

        public ObservableCollection<SkillViewModel> AllowedSkills { get; } = new ObservableCollection<SkillViewModel>();

        public ObservableCollection<SpellViewModel> Spells { get; } = new ObservableCollection<SpellViewModel>();

        public ObservableCollection<SkillViewModel> Skills { get; } = new ObservableCollection<SkillViewModel>();

        public ObservableCollection<SkillViewModelSimple> SkillsSimple { get; } = new ObservableCollection<SkillViewModelSimple>();

        public ObservableCollection<InjuryViewModel> Injuries { get; } = new ObservableCollection<InjuryViewModel>();

        public ObservableCollection<InjuryViewModelSimple> InjuriesSimple = new ObservableCollection<InjuryViewModelSimple>();

        /// <summary>
        /// Gets the buy warrior command.
        /// </summary>
        /// <value>
        /// The buy warrior command.
        /// </value>
        public ICommand BuyWarriorCommand { get; private set; }

        /// <summary>
        /// Gets the decrease warrior buy amount command.
        /// </summary>
        /// <value>
        /// The decrease warrior buy amount command.
        /// </value>
        public ICommand DecreaseWarriorBuyAmountCommand { get; private set; }

        /// <summary>
        /// Gets the show skill selector command.
        /// </summary>
        /// <value>
        /// The show skill selector command.
        /// </value>
        public ICommand ShowSkillSelectorCommand { get; }

        /// <summary>
        /// Gets the equipment costs.
        /// </summary>
        /// <value>
        /// The equipment costs.
        /// </value>
        public int EquipmentCosts { get { return Warrior.EquipmentCosts; } }

        /// <summary>
        /// Gets or sets the experience list.
        /// </summary>
        /// <value>
        /// The experience list.
        /// </value>
        public IReadOnlyCollection<IExperience> ExperienceList { get; set; }

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

        public void RemoveEquipment(EquipmentSummaryViewModel equipment)
        {
            EquippedWeapons.Remove(equipment);
            Warrior.RemoveEquipment(equipment.Equipment);
        }

        public void AddEquipment(EquipmentSummaryViewModel equipment)
        {
            EquippedWeapons.Add(equipment);
            Warrior.AddEquipment(equipment.Equipment);
        }

        /// <summary>
        /// Gets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText { get { return Warrior.TypeName.SplitCamelCasing(); } }

        /// <summary>
        /// Gets the increase warrior buy amount command.
        /// </summary>
        /// <value>
        /// The increase warrior buy amount command.
        /// </value>
        public ICommand IncreaseWarriorBuyAmountCommand { get; private set; }

        /// <summary>
        /// Gets the initial cost.
        /// </summary>
        /// <value>
        /// The initial cost.
        /// </value>
        public int InitialCost { get { return Warrior.HireFee; } }

        /// <summary>
        /// Gets the maximum allowed in war band.
        /// </summary>
        /// <value>
        /// The maximum allowed in war band.
        /// </value>
        public string MaximumAllowedInWarBand
        {
            get
            {
                if (Warrior.MaximumAllowedInWarBand == int.MaxValue)
                {
                    return "∞";
                }
                return Warrior.MaximumAllowedInWarBand.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return Warrior.Name; }
            set
            {
                if (value != Warrior.Name)
                {
                    Warrior.Name = value;
                }
            }
        }

        /// <summary>
        /// Gets the remove warrior command.
        /// </summary>
        /// <value>
        /// The remove warrior command.
        /// </value>
        public ICommand RemoveWarriorCommand { get; private set; }

        /// <summary>
        /// Gets the show group buy buttons.
        /// </summary>
        /// <value>
        /// The show group buy buttons.
        /// </value>
        public Visibility ShowGroupBuyButtons
        {
            get
            {
                if (Warrior is IHenchMen) { return Visibility.Visible; }

                return Visibility.Hidden;
            }
        }

        /// <summary>
        /// Gets the show magic pane.
        /// </summary>
        /// <value>
        /// The show magic pane.
        /// </value>
        public Visibility ShowMagicPane
        {
            get
            {
                if (Warrior is IWizard) { return Visibility.Visible; }

                return Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Gets the show skill pane.
        /// </summary>
        /// <value>
        /// The show skill pane.
        /// </value>
        public Visibility ShowSkillPane
        {
            get
            {
                if (Warrior is IHenchMen) { return Visibility.Collapsed; }

                return Visibility.Visible;
            }
        }

        /// <summary>
        /// Gets the show injury pane.
        /// </summary>
        /// <value>
        /// The show injury pane.
        /// </value>
        public Visibility ShowInjuryPane
        {
            get
            {
                if (Warrior is IHenchMen) { return Visibility.Collapsed; }

                return Visibility.Visible;
            }
        }

        /// <summary>
        /// Gets the show weapons picker command.
        /// </summary>
        /// <value>
        /// The show weapons picker command.
        /// </value>
        public ICommand ShowWeaponsPickerCommand { get; private set; }

        /// <summary>
        /// Gets the warrior.
        /// </summary>
        /// <value>
        /// The warrior.
        /// </value>
        public IWarrior Warrior { get; private set; }

        private void Warrior_PropertiesChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent(nameof(EquipmentCosts));
            RaisePropertyChangedEvent(nameof(GroupCosts));
            RaisePropertyChangedEvent(nameof(GroupCount));
        }
    }
}