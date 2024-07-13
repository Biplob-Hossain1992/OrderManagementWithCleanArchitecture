using Dapper;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.ViewModel;
using OrderManagement.Domain.Entities;
using System.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbContext;
        public OrderRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VmResponseMessage> CreateOrder(VmOrder vm)
        {
            var response = new VmResponseMessage();
            var paramerter = new DynamicParameters();
            paramerter.Add("@ReferenceId", vm.ReferenceId, DbType.Int32);
            paramerter.Add("@OrderNo", vm.OrderNo, DbType.String);
            paramerter.Add("@OrderDateString", vm.OrderDateString, DbType.String);
            paramerter.Add("@SupplierId", vm.SupplierId, DbType.Int32);
            paramerter.Add("@ExpectedDateString", vm.ExpectedDateString, DbType.String);
            paramerter.Add("@ItemId", vm.ItemId, DbType.Int32);
            paramerter.Add("@Quantity", vm.Quantity, DbType.Int32);
            paramerter.Add("@Amount", vm.Amount, DbType.Decimal);
            paramerter.Add("@Remarks", vm.Remarks, DbType.String);
            await _dbContext.ExecuteAsync("[Order].[USP_CreateOrder]", paramerter, commandType: CommandType.StoredProcedure);
            response.Type = "Success";
            response.Message = "Order Created Successfully..!";
            return response;
        }
        public async Task<Order> GetById(int id)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.QueryFirstOrDefaultAsync<Order>("[Order].[USP_GetById]", paramerter, commandType: CommandType.StoredProcedure);
            return data!;
        }
        public async Task<List<VmOrder>> GetAllOrder()
        {
            var data = await _dbContext.QueryAsync<VmOrder>("[Order].[USP_GetAllOrder]", null, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<VmResponseMessage> UpdateOrder(VmOrder vm)
        {
            var response = new VmResponseMessage();
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", vm.Id, DbType.Int32);
            paramerter.Add("@OrderNo", vm.OrderNo, DbType.String);
            paramerter.Add("@OrderDateString", vm.OrderDateString, DbType.String);
            paramerter.Add("@SupplierId", vm.SupplierId, DbType.Int32);
            paramerter.Add("@ExpectedDateString", vm.ExpectedDateString, DbType.String);
            paramerter.Add("@ItemId", vm.ItemId, DbType.Int32);
            paramerter.Add("@Quantity", vm.Quantity, DbType.Int32);
            paramerter.Add("@Amount", vm.Amount, DbType.Decimal);
            paramerter.Add("@Remarks", vm.Remarks, DbType.String);
            await _dbContext.ExecuteAsync("[Order].[USP_UpdateOrder]", paramerter, commandType: CommandType.StoredProcedure);
            response.Type = "Success";
            response.Message = "Order Updated Successfully..!";
            return response;
        }
        public async Task<VmResponseMessage> RemoveOrder(int id)
        {
            var response = new VmResponseMessage();
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", id, DbType.Int32);
            await _dbContext.ExecuteAsync("[Order].[USP_RemoveOrder]", paramerter, commandType: CommandType.StoredProcedure);
            response.Type = "Success";
            response.Message = "Order Deleted Successfully..!";
            return response;
        }
    }
}
