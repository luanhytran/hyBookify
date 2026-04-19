using Asp.Versioning;
using hyBookify.Application.Reviews.AddReview;
using hyBookify.Application.Reviews.DeleteReview;
using hyBookify.Application.Reviews.GetReview;
using hyBookify.Application.Reviews.UpdateReview;
using hyBookify.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hyBookify.Api.Controllers.Reviews;

[Authorize]
[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/reviews")]
public class ReviewsController : ControllerBase
{
    private readonly ISender _sender;

    public ReviewsController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetReviews(CancellationToken cancellationToken)
    {
        var query = new GetAllReviewsQuery();

        Result<IReadOnlyList<ReviewResponse>> result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(Guid id, UpdateReviewRequest request, CancellationToken cancellationToken)
    {
        var update = new UpdateReviewCommand(id, request.Rating, request.Comment);

        var result = await _sender.Send(update, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddReview(AddReviewRequest request, CancellationToken cancellationToken)
    {
        var command = new AddReviewCommand(request.BookingId, request.Rating, request.Comment);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(Guid id, CancellationToken cancellationToken)
    {
        var delete = new DeleteReviewCommand(id);

        var result = await _sender.Send(delete, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok();
    }
}