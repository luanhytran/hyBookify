using hyBookify.Application.Abstractions.Messaging;

namespace hyBookify.Application.Reviews.GetReview;

public sealed record GetAllReviewsQuery : IQuery<IReadOnlyList<ReviewResponse>>;