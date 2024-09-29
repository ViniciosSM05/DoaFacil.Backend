using FluentValidation;

namespace DoaFacil.Backend.Application.Commands.Base
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : class, ICommand
    {
    }
}