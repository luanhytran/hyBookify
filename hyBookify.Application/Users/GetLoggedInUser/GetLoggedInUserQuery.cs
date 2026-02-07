using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Users.GetLoggedInUser;

public sealed record GetLoggedInUserQuery : IQuery<UserResponse>;