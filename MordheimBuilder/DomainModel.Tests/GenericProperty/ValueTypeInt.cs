using System;

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