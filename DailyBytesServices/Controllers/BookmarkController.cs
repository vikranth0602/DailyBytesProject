using DailyBytesDAL.Models;

using DailyBytesDAL.Repositories.Interfaces;
using DailyBytesServices.DTOs.Bookmark;
using DailyBytesServices.Helpers;
using Microsoft.AspNetCore.Mvc;
using DailyBytesServices.Mappers.Bookmark;

namespace DailyBytesServices.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class BookmarkController
        : ControllerBase
    {
        private readonly IBookmarkRepository
            _repository;

        public BookmarkController(
            IBookmarkRepository repository)
        {
            _repository = repository;
        }


        #region Add Bookmark
        [HttpPost]
        public async Task<IActionResult>
            AddBookmark(BookmarkDTO dto)
        {
                var exists =
                    await _repository.ExistsAsync(
                        dto.UserId,
                        dto.ArticleId);

                if (exists)
                {
                    return BadRequest(
                         new ApiResponse<object>
                         {
                             Success = false,
                             Message = "Already bookmarked",
                             Data = null
                         }
                    );
                }

                var bookmark = new Bookmark
                {
                    UserId = dto.UserId,

                    ArticleId = dto.ArticleId
                };

                await _repository.AddAsync(bookmark);

                return Ok(
                    new ApiResponse<object>
                    {
                        Success = true,
                        Message = "Bookmarked",
                        Data = null
                    }
                );
        }
        #endregion


        #region Remove Bookmark
        [HttpDelete]
        public async Task<IActionResult>
            RemoveBookmark(int userId, int articleId)
        {
            await _repository.RemoveAsync(
                userId,
                articleId);

            return Ok(
                new ApiResponse<object>
                {
                    Success = true,
                    Message = "Bookmark removed",
                    Data = null
                }
            );
        }

        #endregion

       
        #region Get Bookmarks
        [HttpGet("{userId}")]
        public async Task<IActionResult>
        GetBookmarks(int userId)
        {
            var bookmarks =
            await _repository
            .GetUserBookmarksAsync(userId);

            var result = bookmarks.Select( b => b.ToBookmarkResponseDTO() );

            return Ok( new ApiResponse<IEnumerable<BookmarkResponseDTO>>
                {
                    Success = true,
                    Message = "Bookmarks fetched",
                    Data = result
                }
            );

        }

        #endregion

    }
}