using Dapper;
using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Repositories
{
    public class SeedDataRepository : ISeedDataRepository
    {
        private readonly IDbConnection _dbContext;
        public SeedDataRepository(IDbConnection dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateDefaultOrder()
        {
            var paramerter = new DynamicParameters();
            paramerter.Add("@ReferenceId", 001, DbType.Int32);
            paramerter.Add("@OrderNo", "1001", DbType.String);
            paramerter.Add("@OrderDate", DateTime.Now, DbType.DateTime);
            paramerter.Add("@SupplierId", 1, DbType.Int32);
            paramerter.Add("@ExpectedDate", DateTime.Now, DbType.DateTime);
            paramerter.Add("@ItemId", 1, DbType.Int32);
            paramerter.Add("@Quantity", 10, DbType.Int32);
            paramerter.Add("@Amount", 1200, DbType.Decimal);
            paramerter.Add("@Remarks", "Default Order", DbType.String);
            await _dbContext.ExecuteAsync("[Order].[USP_DefaultOrder]", paramerter, commandType: CommandType.StoredProcedure);
        }
    }
}
