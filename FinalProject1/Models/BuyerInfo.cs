using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1.Models
{
    public class BuyerInfo
    {
        [Key]
        [Required(ErrorMessage = "This field is requied")]
        public int BuyerID { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String BuyerName { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String BuyerAge { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String BuyerAddress { get; set; }

        public int PaymentID { get; set; }

        [ForeignKey("BuyerID")]
        public PaymentInfo PaymentInfo { get; set; }
    }
}
