using DomainModel.Psychology;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Name = psychology.Name;
            Description = psychology.Description;
        }

        public ObservableCollection<AfflictionViewModel> Afflictions { get; } = new ObservableCollection<AfflictionViewModel>();

        public string Description { get; }
        public string Name { get; }
    }
}