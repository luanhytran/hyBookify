using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Reviews.DeleteReview;

public sealed record DeleteReviewCommand(Guid ReviewId) : ICommand;