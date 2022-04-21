using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1.Models
{
    public class PaymentInfo
    {
        [Key]
        [Required(ErrorMessage = "This field is requied")]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String PaymentMethod { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String BankName { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String CardNumer { get; set; }
    }
}
