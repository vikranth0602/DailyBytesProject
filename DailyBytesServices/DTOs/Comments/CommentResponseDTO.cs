namespace DailyBytesServices.DTOs.Comment
{
    public class CommentResponseDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ArticleId { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; }

        public string UserName { get; set; } = string.Empty;
    }
}