using System;

namespace GS.Domain.Models
{
    public interface IHaveDateCreated
    {
        public DateTime DateCreated { get; set; }
    }
}
