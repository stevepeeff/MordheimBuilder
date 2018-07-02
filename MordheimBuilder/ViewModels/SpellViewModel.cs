using DomainModel.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder.ViewModels
{
    public class SpellViewModel
    {
        public SpellViewModel(ISpell spell)
        {
            Difficulty = spell.Difficulty;
            Description = spell.Description;
        }

        public int Difficulty { get; }

        public string Description { get; }
    }
}