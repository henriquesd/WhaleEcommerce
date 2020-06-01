using WhaleEcommerce.Domain.Interfaces;
using WhaleEcommerce.Domain.Models;
using WhaleEcommerce.Domain.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace WhaleEcommerce.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotifyer _notifyer;

        protected BaseService(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifyer.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
