namespace DailyBytesServices.DTOs.Article
{
    public class ArticleDetailDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}