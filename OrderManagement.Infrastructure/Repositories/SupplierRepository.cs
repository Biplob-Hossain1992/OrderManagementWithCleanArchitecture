using Dapper;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Domain.Entities;
using System.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class SupplierRepository: ISupplierRepository
    {
        private readonly IDbConnection _dbContext;
        public SupplierRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Supplier>> GetAllSupplier()
        {
            var data = await _dbContext.QueryAsync<Supplier>("[Supplier].[USP_GetAllSupplier]", null, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
    }
}
