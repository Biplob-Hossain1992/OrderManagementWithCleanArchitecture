using Dapper;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.ViewModel;
using OrderManagement.Infrastructure.Service;
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
            var dataTable = DataTableCreator.CreateDataTable(vm.OrderItem); //convert to datatable
            var parameter = new DynamicParameters();
            parameter.Add("@ReferenceId", vm.ReferenceId, DbType.Int32);
            parameter.Add("@OrderNo", vm.OrderNo, DbType.String);
            parameter.Add("@OrderDate", vm.OrderDate, DbType.DateTime);
            parameter.Add("@SupplierId", vm.SupplierId, DbType.Int32);
            parameter.Add("@ExpectedDate", vm.ExpectedDate, DbType.DateTime);
            parameter.Add("@Remarks", vm.Remarks, DbType.String);
            parameter.Add("@OrderItem", dataTable.AsTableValuedParameter("[Order].[OrderItems]")); //added order items as parameter

            var data =  await _dbContext.ExecuteAsync("[Order].[USP_CreateOrder]", parameter, commandType: CommandType.StoredProcedure);
            if(data > 0)
            {
                response.Type = "Success";
                response.Message = "Order Created Successfully..!";
            }
            return response;
        }
        public async Task<List<VmOrderItem>> GetById(int id)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@Id", id, DbType.Int32);
            var data = await _dbContext.QueryAsync<VmOrderItem>("[Order].[USP_GetById]", paramerter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<List<VmOrder>> GetAllOrder(int CurPage, int TakeRows)
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@SkipRows", CurPage, DbType.Int32);
            paramerter.Add("@TakeRows", TakeRows, DbType.Int32);
            var data = await _dbContext.QueryAsync<VmOrder>("[Order].[USP_GetAllOrder]", paramerter, commandType: CommandType.StoredProcedure);
            return data.ToList();
        }
        public async Task<VmResponseMessage> UpdateOrder(VmOrder vm)
        {
            var response = new VmResponseMessage();
            var dataTable = DataTableCreator.CreateDataTable(vm.OrderItem); //convert to datatable
            var parameter = new DynamicParameters();
            parameter.Add("@Id", vm.Id, DbType.Int32);
            parameter.Add("@OrderNo", vm.OrderNo, DbType.String);
            parameter.Add("@OrderDate", vm.OrderDate, DbType.DateTime);
            parameter.Add("@SupplierId", vm.SupplierId, DbType.Int32);
            parameter.Add("@ExpectedDate", vm.ExpectedDate, DbType.DateTime);
            parameter.Add("@Remarks", vm.Remarks, DbType.String);
            parameter.Add("@OrderItem", dataTable.AsTableValuedParameter("[Order].[OrderItems]")); //added order items as parameter

            var data = await _dbContext.ExecuteAsync("[Order].[USP_UpdateOrder]", parameter, commandType: CommandType.StoredProcedure);
            if (data > 0)
            {
                response.Type = "Success";
                response.Message = "Order Updated Successfully..!";
            }
            return response;
        }
        public async Task<VmResponseMessage> RemoveOrder(int id)
        {
            var response = new VmResponseMessage();
            var parameter = new DynamicParameters();
            parameter.Add("@Id", id, DbType.Int32);
            await _dbContext.ExecuteAsync("[Order].[USP_RemoveOrder]", parameter, commandType: CommandType.StoredProcedure);
            response.Type = "Success";
            response.Message = "Order Deleted Successfully..!";
            return response;
        }
    }
}
