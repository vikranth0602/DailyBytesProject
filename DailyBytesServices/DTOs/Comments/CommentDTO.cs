using System.ComponentModel.DataAnnotations;

namespace DailyBytesServices.DTOs.Comment
{
    public class CommentDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(500)]
        public string Message { get; set; }
    }

}
