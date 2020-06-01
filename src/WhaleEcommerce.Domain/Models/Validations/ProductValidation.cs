using FluentValidation;

namespace WhaleEcommerce.Domain.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must be informed")
                .Length(2, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}