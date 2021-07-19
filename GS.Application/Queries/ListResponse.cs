using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GS.Application.Queries
{
    public class ListResponse<T>
    {
        public virtual IList<T> Items { get; set; }

        public ListResponse(IEnumerable<T> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            Items = items as List<T> ?? items.ToList();
        }
    }
}
