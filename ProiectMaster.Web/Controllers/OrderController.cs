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
    public class OrderController : Controller
    {
        private readonly IOrderService service;
        

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = service.GetAllOrders();
            return View(list);
        }

        [HttpGet]
        [Route("New")]
        public IActionResult New()
        {
            var dto = new OrderVM();
            return View(dto);
        }

        [HttpPost]
        [Route("New")]
        public IActionResult New(OrderVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            service.AddGetOrders(dto);

            return View("Index", service.GetAllOrders());
            
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "There were some errors in your form");
                    return View("Index", service.GetAllOrders());

                }
                var dto = service.GetOrders(id);
            return View(dto);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, OrderVM dto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "There were some errors in your form");
                return View(dto);
            }

            service.UpdateGetOrders(id, dto);

            return View("Index", service.GetAllOrders());
            
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public JsonResult Delete(int id)
        {
            service.DeleteGetOrders(id);
            return Json(new { success = true, message = "Delete success" });
        }
    }
}
