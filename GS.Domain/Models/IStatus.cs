using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Domain.Models
{
    public interface IStatus<T>
    {
        T Status { get; set; }
    }
}
