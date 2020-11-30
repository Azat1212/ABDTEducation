using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using PriceService.Models;
using Repository;

namespace PriceService.Repositories
{
    public class PriceRepository : BaseRepository<PriceDbModel>, IPriceRepository
    {

        public PriceRepository(IOptions<PriceDbOptions> dbOptions) : base(dbOptions)
        {
        }

        public async Task<IEnumerable<PriceDbModel>> GetByProductId(Guid productId, bool lasted = true)
        {
            await using var db = await GetSqlConnection();

            return await db.QueryAsync<PriceDbModel>($"SELECT * FROM  [{typeof(PriceDbModel).Name}] WHERE [ProductId] = @productId AND [IsLast] = @lasted AND [IsDeleted] = 0", new { productId, lasted });
        }

        public async Task<bool> UpdateByProductId(Guid productId, double price)
        {
            await using var db = await GetSqlConnection();

            return await db.ExecuteAsync($"UPDATE [{typeof(PriceDbModel).Name}] SET IsLast = 0 WHERE [ProductId] = @productId AND [Currency] = @currency AND [IsDeleted] = 0",
                new { productId, price }) != 0;
        }

        public async Task<bool> DeleteByProductId(Guid productId)
        {
            await using var db = await GetSqlConnection();

            return await db.ExecuteAsync($"UPDATE [{typeof(PriceDbModel).Name}] SET IsDeleted = 1 WHERE productId = @productId", new { productId }) != 0;
        }




    }

}
