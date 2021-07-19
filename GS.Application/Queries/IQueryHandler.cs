using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
        where TQuery: IQuery<TResult>
    {
    }
}
