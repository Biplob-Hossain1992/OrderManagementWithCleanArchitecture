using Dapper;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;
using System.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly IDbConnection _dbContext;
        public ItemRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Item>> GetAllItem()
        {
            var data = await _dbContext.QueryAsync<Item>("[Item].[USP_GetAllItem]", null, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
