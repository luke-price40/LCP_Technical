using FluentValidation;

namespace Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .MaximumLength( 50 )
                .NotEmpty();

            RuleFor(c => c.LastName)
                .MaximumLength(50)
                .NotEmpty();

            RuleFor(c => c.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }
}
