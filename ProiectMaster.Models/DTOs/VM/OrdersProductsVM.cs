using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMaster.Models.DTOs.VM
{
   public class OrdersProductsVM
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int OrderId{ get; set; }
       
    }
}
