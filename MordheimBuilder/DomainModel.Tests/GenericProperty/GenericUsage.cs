using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Tests
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/generic-classes

    internal class GenericUsage : GenericBase<int>
    {
        public GenericUsage(int theValue)
        {
            Value = theValue;
            TheValueType = theValue;
        }

        public GenericUsage()
        {
        }

        public override ValueType TheValueType { get; set; }

        public override int Value { get; set; }

        //public GenericBase<T> TheValue { get; set; }
        //GenericBase<T> TheValue { get; set; }
    }
}