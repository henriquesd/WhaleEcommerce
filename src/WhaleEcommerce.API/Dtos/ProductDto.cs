using System;
using System.ComponentModel.DataAnnotations;

namespace WhaleEcommerce.API.Dtos
{
    public class ProductDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(350, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime PublishDate { get; set; }
        public bool Active { get; set; }
    }
}
