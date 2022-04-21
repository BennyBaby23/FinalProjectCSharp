using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1.Models
{
    public class AboutProduct
    {
        [Key]
        
        public int ProductID { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String ProductName { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String AboutProducts { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public int Productprice { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String ProductMadeCountry { get; set; }

        public int ProductStoreID { get; set; }
        
        [ForeignKey("ProductStoreID")]
        public ProuctSore ProductSore { get; set; }

        public int ProductoverviewID { get; set; }

        [ForeignKey("ProductoverviewID")]
        public ProuctOverview ProuctOverview { get; set; }

        public int BuyerID { get; set; }

        [ForeignKey("BuyerID")]
        public BuyerInfo BuyerInfo { get; set; }
    }
}
