using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Reviews.AddReview;

public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;