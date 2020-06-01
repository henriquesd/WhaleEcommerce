using FluentValidation;

namespace WhaleEcommerce.Domain.Models.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The field {PropertyName} must be informed")
                .Length(2, 100)
                .WithMessage("The field {PropertyName} must have between {MinLength} and {MaxLength} characters");
        }
    }
}