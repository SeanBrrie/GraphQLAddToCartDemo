using GraphQLDemo.API.Data;
using GraphQLDemo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Carts
{
    public class CartDataLoaders : BatchDataLoader<int, Cart>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public CartDataLoaders(
            IBatchScheduler batchScheduler,
            IDbContextFactory<ApplicationDbContext> dbContextFactory)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, Cart>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using ApplicationDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            // Include cart products and products in the query
            return await dbContext.Carts
                 .Where(c => keys.Contains(c.Id))
                 .Include(c => c.CartProducts)
                 .ThenInclude(cp => cp.Product)
                 .ToDictionaryAsync(t => t.Id, cancellationToken);


        }

    }
}
