namespace hyBookify.Domain.Reviews;

public interface IReviewRepository
{
    Task<Review?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    void Add(Review review);

    void Remove(Review review);
}