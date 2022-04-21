using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1.Models
{
    public class ProuctSore
    {
        [Key]
        [Required(ErrorMessage = "This field is requied")]
        public int ProductStoreID { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String StoreName { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String StoreAddress { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String StoreReview { get; set; }
    }
}
