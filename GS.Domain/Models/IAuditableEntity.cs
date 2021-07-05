using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Domain.Models
{
    public interface IAuditableEntity: IHaveUserCreated, IHaveUserUpdate, IHaveDateCreated, IHaveDateUpdated
    {
    }
}
