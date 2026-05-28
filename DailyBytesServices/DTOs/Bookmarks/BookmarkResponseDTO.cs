namespace DailyBytesServices.DTOs.Bookmark
{
    public class BookmarkResponseDTO
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}