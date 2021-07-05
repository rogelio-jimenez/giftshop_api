using System;

namespace GS.Domain.Models
{
    public interface IHaveUserCreated
    {
        public Guid CreatedBy { get; set; }
    }
}
