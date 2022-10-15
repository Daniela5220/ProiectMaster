using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;


namespace ProiectMaster.Models.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderVM> GetAllOrders();
        OrderVM GetOrders(int id);
        void AddGetOrders(OrderVM dto);
        void UpdateGetOrders(int id, OrderVM dto);
        void DeleteGetOrders(int id);

        /* List<IdNameDto> GetProductTypes();*/
    }
}
