using hyBookify.Application.Abstractions.Data;
using hyBookify.Application.Abstractions.Messaging;
using hyBookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace hyBookify.Application.Reviews.GetReview;

internal sealed class GetAllReviewsQueryHandler : IQueryHandler<GetAllReviewsQuery, IReadOnlyList<ReviewResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetAllReviewsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<IReadOnlyList<ReviewResponse>>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _context.Reviews
            .Select(r => new ReviewResponse
            {
                Id = r.Id,
                ApartmentId = r.ApartmentId,
                BookingId = r.BookingId,
                UserId = r.UserId,
                Rating = r.Rating.Value,
                Comment = r.Comment.Value,
                CreatedOnUtc = r.CreatedOnUtc
            })
            .ToListAsync(cancellationToken);

        return reviews;
    }
}