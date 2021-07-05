using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Domain.Models
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public void EnsureId()
        {
            if (Id == default)
                Id = Guid.NewGuid();
        }
    }
}
