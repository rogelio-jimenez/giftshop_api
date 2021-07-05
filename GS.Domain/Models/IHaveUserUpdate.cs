using System;

namespace GS.Domain.Models
{
    public interface IHaveUserUpdate
    {
        public Guid UpdatedBy { get; set; }
    }
}
