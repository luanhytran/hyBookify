using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Users.LogInUser
{
    public sealed record LogInUserCommand(string Email, string Password)
        : ICommand<AccessTokenResponse>;
}