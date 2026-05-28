using DailyBytesDAL.Models;

using DailyBytesDAL.Repositories.Interfaces;
//using DailyBytesServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using DailyBytesServices.Mappers.Comment;
using DailyBytesServices.Helpers;
using DailyBytesServices.DTOs.Comment;

namespace DailyBytesServices.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class CommentController
        : ControllerBase
    {
        private readonly ICommentRepository
            _repository;

        public CommentController(
            ICommentRepository repository
        )
        {
            _repository = repository;
        }

        // ADD COMMENT
        #region-AddComment
        [HttpPost]
        public async Task<IActionResult>
            AddComment(CommentDTO dto)
        {
   
                var comment = new Comment
                {
                    UserId = dto.UserId,

                    ArticleId = dto.ArticleId,

                    Message = dto.Message,

                    CreatedDate = DateTime.Now
                };

                await _repository
                    .AddCommentAsync(comment);

                return Ok(
                   new ApiResponse<object>
                   {
                       Success = true,
                       Message = "Comment added",
                       Data = null
                   }
                );
           
        }
        #endregion

        // GET COMMENTS
        #region-GetComment
        [HttpGet("{articleId}")]
        public async Task<IActionResult> GetComments( int articleId )
        {
           
                var comments =
                    await _repository.GetCommentsByArticleAsync(articleId);

                var result =
                    comments.Select(c => c.ToCommentResponseDTO()).ToList();

                    return Ok(
                        new ApiResponse<List<CommentResponseDTO>>
                        {
                            Success = true,
                            Message = "Comments fetched",
                            Data = result
                        }
                    );
          
        }
        #endregion

        // DELETE COMMENT
        #region-DeleteComment
        [HttpDelete("{id}")]
        public async Task<IActionResult>
        DeleteComment(int id)
        {
      
                await _repository
                    .DeleteCommentAsync(id);

                return Ok(
                    new ApiResponse<object>
                    {
                        Success = true,
                        Message = "Comment deleted",
                        Data = null
                    }
                );
            
          
        }
        #endregion


    }
}