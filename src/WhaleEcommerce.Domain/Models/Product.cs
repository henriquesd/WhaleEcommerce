using System;

namespace WhaleEcommerce.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool Active { get; set; }
    }
}
