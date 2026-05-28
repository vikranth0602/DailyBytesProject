namespace DailyBytesServices.DTOs.Article
{
    public class ArticleListDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string PreviewText { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty;
    }
}