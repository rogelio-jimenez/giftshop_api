using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace GS.Application.Contracts.Repository
{
    public interface IRepositoryAsync<T>: IRepositoryBase<T> where T : class
    {

    }

    //public interface IReadOnlyRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    //{

    //}
}
