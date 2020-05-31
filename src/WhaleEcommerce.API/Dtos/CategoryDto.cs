using System;
using System.ComponentModel.DataAnnotations;

namespace WhaleEcommerce.API.Dtos
{
    public class CategoryDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }
    }
}
