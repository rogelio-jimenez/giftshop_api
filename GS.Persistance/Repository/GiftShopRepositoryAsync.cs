using Ardalis.Specification.EntityFrameworkCore;
using GS.Application.Contracts.Repository;
using GS.Persistance.Contexts;

namespace GS.Persistance.Repository
{
    public class GiftShopRepositoryAsync<T>: RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly GiftShopDBContext _context;

        public GiftShopRepositoryAsync(GiftShopDBContext context): base(context)
        {
            _context = context;
        }



    }
}
