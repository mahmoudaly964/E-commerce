using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace E_commerceRazor.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order for category must be between 0-100")]
        public int DisplayOrder { get; set; }
    }
}
