using OrderManagement.Application.Interfaces.IRepositories;
using OrderManagement.Application.ViewModel;

namespace OrderManagement.Infrastructure.Service
{
    public class DatabaseSeeder
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ISupplierRepository _supplierRepository;
        public DatabaseSeeder(IOrderRepository orderRepository, IItemRepository itemRepository, ISupplierRepository supplierRepository)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
            _supplierRepository = supplierRepository;
        }
        public async Task SeedDatabaseAsync()
        {
            #region Order Create
            var list = new List<VmTableValuedParameter>();
            var model = new VmOrder
            {
                ReferenceId = 001,
                OrderNo = "1001",
                OrderDate = DateTime.Now,
                SupplierId = 1,
                ExpectedDate = DateTime.Now,
                Remarks = "Create Default Order"
            };
            for (int i = 0; i < 3; i++)
            {
                var orderItem = new VmTableValuedParameter
                {
                    OrderId = 1,
                    ItemId = i + 1,
                    Quantity = 5 + i,
                    Rate = 12
                };
                list.Add(orderItem);
            }
            model.OrderItem = list;
            await _orderRepository.CreateOrder(model);
            #endregion

            #region Supplier Create
            var supplier = new VmSupplier
            {
                Name = "Biplob Hossain",
                PhoneNumber = "01303040782",
                Address = "Eastern Housing, Pallabi, Mirpur-12, Dhaka"
            };
            await _supplierRepository.CreateSupplier(supplier);
            #endregion

            #region Item Create
            var item = new VmItem
            {
                Name = "Samsung Galaxy A5",
                UnitPrice = 50000
            };
            await _itemRepository.CreateItem(item);
            #endregion
        }
    }
}
