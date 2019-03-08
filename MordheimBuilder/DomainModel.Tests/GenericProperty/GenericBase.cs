using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Tests
{
    internal abstract class GenericBase<T> : IGenericBase<T>
    {
        public abstract T Value { get; set; }

        //public static implicit operator T(MyProp<T> value)
        //{
        //    return value.Value;
        //}

        //public static implicit operator MyProp<T>(T value)
        //{
        //    return new MyProp<T> { Value = value };
        //}
    }
}