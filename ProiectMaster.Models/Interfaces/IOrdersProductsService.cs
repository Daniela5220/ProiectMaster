using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using System.Collections.Generic;

namespace ProiectMaster.Models.Interfaces
{
    public interface IOrdersProductsService
    {
       
        IEnumerable<OrdersProductsVM> GetAllOrdersProducts();

        OrdersProductsVM GetOrdersProducts(int id);
        void AddOrdersProducts(OrdersProductsVM dto);
        void UpdateOrdersProducts(int id, OrdersProductsVM dto);
        void DeleteOrdersProducts(int id);
        List<IdNameDto> GetSeviceProducts();
    }
}
