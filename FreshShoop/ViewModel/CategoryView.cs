using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FreshShoop.ViewModel
{
    public class CategoryView
    {
        [DisplayName("Enter Category Name:")]
        [Required(ErrorMessage = "Category Name Is Requried")]
      
        public string Name { get; set; } = null!;
        [Required]

        [DisplayName("Select Image:")]
        public IFormFile Image { get; set; }

    }
}
