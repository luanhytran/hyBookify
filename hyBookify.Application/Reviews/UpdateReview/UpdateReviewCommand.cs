using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Reviews.UpdateReview;

public sealed record UpdateReviewCommand(Guid ReviewId,int Rating, string Comment) : ICommand;