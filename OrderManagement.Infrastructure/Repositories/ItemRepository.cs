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
        public async Task<VmResponseMessage> CreateItem(VmItem vm)
        {
            var response = new VmResponseMessage();
            var parameter = new DynamicParameters();
            parameter.Add("@Name", vm.Name, DbType.String);
            parameter.Add("@UnitPrice", vm.UnitPrice, DbType.Decimal);

            var data = await _dbContext.ExecuteAsync("[Item].[USP_CreateItem]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                response.Type = "Success";
                response.Message = "Item Created Successfully..!";
            }
            return response;
        }
    }
}
