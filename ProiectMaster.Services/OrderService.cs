using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ProiectMaster.DataAccess.Interfaces;
using ProiectMaster.Models.DTOs;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Entites;
using ProiectMaster.Models.Interfaces;
using System.IO;


namespace ProiectMaster.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, int> orderRep;
        private readonly IMapper mapper;

        public OrderService(IRepository<Order, int> orderRep, IMapper mapper)
        {
            this.orderRep =orderRep;
            this.mapper = mapper;
        }
        public void AddGetOrders(OrderVM dto)
        {
            
            var entity = mapper.Map<Order>(dto);
            orderRep.Add(entity);
        }

        void IOrderService.DeleteGetOrders(int id)
        {

            var entity = orderRep.GetInstance(id);
            if (entity == null)
                return;

            orderRep.Delete(entity);
        }

        IEnumerable<OrderVM> IOrderService.GetAllOrders()
        {
            

             var orders = orderRep.GetAll();
            return mapper.Map<List<OrderVM>>(orders);
        }

        OrderVM IOrderService.GetOrders(int id)
        {

            var entity = orderRep.GetInstance(id);
            return mapper.Map<OrderVM>(entity);
        }

        void IOrderService.UpdateGetOrders(int id, OrderVM dto)
        {
            var entity = orderRep.GetInstance(id);
            if (entity == null)
                return;

            mapper.Map(dto, entity);
            orderRep.Update(entity);
        }
    }

      
    
}
