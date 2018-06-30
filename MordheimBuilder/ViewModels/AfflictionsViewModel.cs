using DomainModel.Psychology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class AfflictionsViewModel
    {
        public IList<AfflictionsViewModel> Afflictions { get; set; } = new List<AfflictionsViewModel>();

        private IPsychology _Affliction;

        public AfflictionsViewModel(IReadOnlyCollection<IPsychology> afflictions)
        {
            foreach (IPsychology item in afflictions)
            {
                Afflictions.Add(new AfflictionsViewModel(item));
            }
        }

        private AfflictionsViewModel(IPsychology affliction)
        {
            _Affliction = affliction;
        }

        public string Name
        {
            get { return _Affliction.GetType().Name.SplitCamelCasing(); }
        }

        public string Affliction
        {
            get { return _Affliction.Affliction.GetDescription(); }
        }

        public string Description
        {
            get { return _Affliction.Description; }
        }
    }
}