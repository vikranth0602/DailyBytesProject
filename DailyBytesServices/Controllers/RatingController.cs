using DailyBytesDAL.Models;
using DailyBytesDAL.Repositories.Interfaces;
using DailyBytesServices.DTOs.Rating;
using DailyBytesServices.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DailyBytesServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _repository;

        public RatingController(IRatingRepository repository)
        {
            _repository = repository;
        }

        // Submit Rating
        [HttpPost]
        public async Task<IActionResult> AddRating(RatingDTO dto)
        {
            try
            {
                var userIdHeader = Request.Headers["UserId"].FirstOrDefault();

                if (string.IsNullOrEmpty(userIdHeader))
                {
                    return Unauthorized(
                        new ApiResponse<object>
                        {
                            Success = false,
                            Message = "User not logged in",
                            Data = null
                        }
                    );
                }

                int userId = int.Parse(userIdHeader);

                var rating = new Rating
                {
                    UserId = userId,
                    ArticleId = dto.ArticleId,
                    RatingValue = dto.RatingValue
                };

                await _repository.AddOrUpdateRatingAsync(rating);

                return Ok(
                    new ApiResponse<object>
                    {
                        Success = true,
                        Message = "Rating submitted successfully",
                        Data = null
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ApiResponse<object>
                    {
                        Success = false,
                        Message = ex.Message,
                        Data = null
                    }
                );
            }
        }

        // Get Average Rating
        [HttpGet("average/{articleId}")]
        public async Task<IActionResult> GetAverageRating(int articleId)
        {
            try
            {
                var average = await _repository.GetAverageRatingAsync(articleId);

                return Ok(
                    new ApiResponse<double>
                    {
                        Success = true,
                        Message = "Average rating fetched",
                        Data = Math.Round(average, 1)
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ApiResponse<object>
                    {
                        Success = false,
                        Message = ex.Message,
                        Data = null
                    }
                );
            }
        }

        [HttpGet("user/{articleId}")]
        public async Task<IActionResult> GetUserRating( int articleId )
        {
            try
            {
                var userIdHeader =
                    Request.Headers["UserId"]
                    .FirstOrDefault();

                if (string.IsNullOrEmpty(userIdHeader))
                {
                    return Unauthorized(
                        new ApiResponse<object>
                        {
                            Success = false,
                            Message = "User not logged in",
                            Data = null
                        }
                    );
                }

                int userId =
                    int.Parse(userIdHeader);

                var rating =
                    await _repository
                        .GetUserRatingAsync(
                            userId,
                            articleId
                        );

                return Ok(
                    new ApiResponse<int>
                    {
                        Success = true,
                        Message = "User rating fetched",
                        Data = rating?.RatingValue ?? 0
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ApiResponse<object>
                    {
                        Success = false,
                        Message = ex.Message,
                        Data = null
                    }
                );
            }
        }

    }
}