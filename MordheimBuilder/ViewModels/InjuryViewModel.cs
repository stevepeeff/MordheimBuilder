using DomainModel.Injuries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class InjuryViewModel : InjuryViewModelSimple
    {
        public InjuryViewModel(Injury injury) : base(injury)
        {
            Description = injury.Description;
        }

        public string Description { get; }
    }
}