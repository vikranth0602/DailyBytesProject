using System.ComponentModel.DataAnnotations;

namespace DailyBytesServices.DTOs.Bookmark
{
    public class BookmarkDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }
    }

}
