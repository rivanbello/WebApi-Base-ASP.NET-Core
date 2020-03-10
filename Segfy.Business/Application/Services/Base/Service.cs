using FluentValidation;
using FluentValidation.Results;
using Segfy.Core.Business.Interfaces.Arguments;
using Segfy.Core.Business.Models.Base;
using Segfy.Core.Notifications;

namespace Segfy.Core.Application.Services.Base
{
    public class Service
    {
        private readonly INotifier _notifier;

        public Service(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entit) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entit);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
