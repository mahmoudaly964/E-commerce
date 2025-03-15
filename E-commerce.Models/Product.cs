using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        public string Author { get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(0,1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-500")]
        [Range(0, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+ ")]
        [Range(0, 1000)]
        public double Price50 { get; set; }


        [Required]
        [Display(Name = "Price for 100+")]
        [Range(0, 1000)]
        public double Price100 { get; set; }

    }
}
