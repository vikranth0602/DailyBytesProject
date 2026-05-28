using DailyBytesDAL.Models;

using DailyBytesServices.DTOs.Article;

namespace DailyBytesServices.Mappers.Article
{
    public static class ArticleMapper
    {
        public static ArticleListDTO
        ToArticleListDTO(
        this DailyBytesDAL.Models.Article article
        )
        {
            var content =
            article.Content ?? string.Empty;

        return new ArticleListDTO
        {
            Id = article.Id,

            Title = article.Title,

            PreviewText =
                content.Length > 120
                ? content.Substring(0, 120) + "..."
                : content,

            CategoryName =
                article.Category?.Name ?? "Unknown"
        };
        }

        public static ArticleDetailDTO
            ToArticleDetailDTO(
                this DailyBytesDAL.Models.Article article
            )
        {
            return new ArticleDetailDTO
            {
                Id = article.Id,

                Title = article.Title,

                Content =
                    article.Content ?? string.Empty,

                CategoryName =
                    article.Category?.Name ?? "Unknown"
            };
        }
    }


}
