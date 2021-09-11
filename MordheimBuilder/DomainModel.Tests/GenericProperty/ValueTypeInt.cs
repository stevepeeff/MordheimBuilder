using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Tests.GenericProperty
{
    internal class ValueTypeInt : ValueTyepBase
    {
        public ValueTypeInt(int theValue)
        {
            TheValueType = theValue;
        }

        public override ValueType TheValueType { get; set; }
    }
}