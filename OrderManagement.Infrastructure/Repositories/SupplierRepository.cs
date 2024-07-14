using Dapper;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Service;
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
        public async Task<VmResponseMessage> CreateSupplier(VmSupplier vm)
        {
            var response = new VmResponseMessage();
            var parameter = new DynamicParameters();
            parameter.Add("@Name", vm.Name, DbType.String);
            parameter.Add("@PhoneNumber", vm.PhoneNumber, DbType.String);
            parameter.Add("@Address", vm.Address, DbType.String);

            var data = await _dbContext.ExecuteAsync("[Supplier].[USP_CreateSupplier]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                response.Type = "Success";
                response.Message = "Supplier Created Successfully..!";
            }
            return response;
        }
    }
}
