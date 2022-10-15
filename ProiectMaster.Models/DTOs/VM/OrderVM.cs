using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProiectMaster.Models.DTOs.VM
{
   public  class OrderVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(2000)]
        public string CustomerPhoneNumber { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        
    }
}
