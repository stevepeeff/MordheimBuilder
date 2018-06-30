using DomainModel.Injuries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class InjuryViewModelSimple
    {
        public InjuryViewModelSimple(Injury injury)
        {
            Name = injury.Name;
        }

        public string Name { get; }
    }
}