using System.ComponentModel.DataAnnotations;

namespace DailyBytesServices.DTOs.Rating
{
    public class RatingDTO
    {
        //[Required]
        //public int UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        [Range(1, 5)]
        public int RatingValue { get; set; }
    }
}