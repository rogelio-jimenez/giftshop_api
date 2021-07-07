using System;

namespace GS.Domain.Models
{
    public interface IHaveUserCreated
    {
        public Guid UserId { get; set; }
    }
}
