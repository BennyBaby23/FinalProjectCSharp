using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1.Models
{
    public class ProuctOverview
    {
        [Key]
        [Required(ErrorMessage = "This field is requied")]
        public int ProductoverviewID { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String ProductSize { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String ProductParts { get; set; }

        [Required(ErrorMessage = "This field is requied")]
        public String ProductReview { get; set; }
    }
}
