using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand(
            string Email,
            string FirstName,
            string LastName,
            string Password) : ICommand<Guid>;
}