using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Tests.GenericProperty
{
    internal abstract class ValueTyepBase
    {
        public abstract ValueType TheValueType { get; set; }
    }
}