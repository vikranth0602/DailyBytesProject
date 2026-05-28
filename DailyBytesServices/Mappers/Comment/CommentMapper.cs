using DailyBytesServices.DTOs.Comment;

namespace DailyBytesServices.Mappers.Comment
{
    public static class CommentMapper
    {
        public static CommentResponseDTO
        ToCommentResponseDTO(
        this DailyBytesDAL.Models.Comment comment
        )
        {
            return new CommentResponseDTO
            {
                Id = comment.Id,

            UserId = comment.UserId,

                ArticleId = comment.ArticleId,

                Message =
                            comment.Message ?? string.Empty,

                CreatedDate =
                            comment.CreatedDate,

                UserName =
                            comment.User == null
                            ? "Unknown User"
                            : $"{comment.User.FirstName} {comment.User.LastName}"
            };
        }
    }


}
