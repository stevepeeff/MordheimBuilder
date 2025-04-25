namespace DomainModel.Tests
{
    internal interface IGenericBase<T>
    {
        T Value { get; set; }
    }
}