using DomainModel.Psychology;
using System;
using System.Collections.ObjectModel;

namespace MordheimTableTop.Warrior
{
    public class AfflictionViewModel : ViewModelBase
    {
        public AfflictionViewModel(WarriorViewModel warriorViewModel)
        {
            foreach (var item in warriorViewModel.Warrior.Afflictions)
            {
                Afflictions.Add(new AfflictionViewModel(item));
            }
        }

        private AfflictionViewModel(IPsychology psychology)
        {
            Name = psychology.Name.SplitCamelCasing();
            TooltipText = FormatIPsychologyAfflicationDescription(psychology);
        }

        public ObservableCollection<AfflictionViewModel> Afflictions { get; } = new ObservableCollection<AfflictionViewModel>();

        public string Name { get; }

        public string TooltipText { get; }

        private string FormatIPsychologyAfflicationDescription(IPsychology psychology)
        {
            return EnumUtils.GetDescription(psychology.Affliction) +
                    Environment.NewLine +
                    psychology.Description;
        }
    }
}