namespace SalesTest.Domain.Base
{
    /// <summary>Entity with name</summary>
    public interface INamedEntity : IEntity
    {
        /// <summary>Name</summary>
        public string Name { get; set; }
    }
}
