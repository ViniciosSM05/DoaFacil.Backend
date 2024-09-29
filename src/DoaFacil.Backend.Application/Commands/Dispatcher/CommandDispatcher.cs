using DoaFacil.Backend.Application.Commands.Base;
using DoaFacil.Backend.Application.Commands.Notifications.AddNotificationMessage;
using DoaFacil.Backend.Application.Commands.Notifications.AddNotificationValidationResult;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DoaFacil.Backend.Application.Commands.Dispatcher
{
    public class CommandDispatcher(IServiceProvider serviceProvider, IMediator mediator) : ICommandDispatcher
    {
        public async Task<TResult> DispatchAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken = default)
        {
            if (command is null)
                await mediator.Send(new AddNotificationMessageCommand("Comando não pode ser nulo"), cancellationToken);
            else if (await ValidateAsync(command, cancellationToken))
                return await mediator.Send(command, cancellationToken);

            return default;
        }

        private async Task<bool> ValidateAsync<TResult>(Command<TResult> command, CancellationToken cancellationToken)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(command.GetType());
            var validators = serviceProvider.GetServices(validatorType);
            if (validators is null || !validators.Any()) return true;

            var validationContextType = typeof(ValidationContext<>).MakeGenericType(command.GetType());
            var validationContext = (IValidationContext)Activator.CreateInstance(validationContextType, command);

            bool isValid = true;
            foreach (var validator in validators)
            {
                var validationResult = await ((IValidator)validator).ValidateAsync(validationContext, cancellationToken);
                if (!validationResult.IsValid)
                {
                    isValid = false;
                    await mediator.Send(new AddNotificationsFromValidationResultCommand(validationResult), cancellationToken);
                }
            }

            return isValid;
        }
    }
}