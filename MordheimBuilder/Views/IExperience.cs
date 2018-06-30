using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MordheimBuilder
{
    public interface IExperience
    {
        int Index { get; }

        bool IsChecked { get; set; }
    }
}