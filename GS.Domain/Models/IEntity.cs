using System;

namespace GS.Domain.Models
{
    /// <summary>
    /// Represents a model entity with an unique identifier of type <see cref="System.Guid" />.
    /// </summary>
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}
