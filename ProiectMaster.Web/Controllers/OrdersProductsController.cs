using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectMaster.Models.DTOs.VM;
using ProiectMaster.Models.Interfaces;

namespace ProiectMaster.Web.Controllers
{
    [Route("[Controller]")]
    public class OrdersProductsController : Controller
    {
        private readonly IOrdersProductsService service;

        public OrdersProductsController(IOrdersProductsService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = service.GetAllOrdersProducts();
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            var dto = new OrdersProductsVM();
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(OrdersProductsVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            service.AddOrdersProducts(dto);

            return View("Index", service.GetAllOrdersProducts());

        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var dto = service.GetOrdersProducts(id);
            return View(dto);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, OrdersProductsVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            service.UpdateOrdersProducts(id, dto);

            return View("Index", service.GetAllOrdersProducts());

        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            service.DeleteOrdersProducts(id);
            return Json(new { success = true, message = "Delete success" });
        }
    }
}
