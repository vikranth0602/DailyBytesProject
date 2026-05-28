using DailyBytesServices.DTOs.Bookmark;

namespace DailyBytesServices.Mappers.Bookmark
{
    public static class BookmarkMapper
    {
        public static BookmarkResponseDTO
        ToBookmarkResponseDTO(
        this DailyBytesDAL.Models.Bookmark bookmark
        )
        {
            return new BookmarkResponseDTO
            {
                Id = bookmark.Id,

                ArticleId =  bookmark.ArticleId,

                Title =
                            bookmark.Article?.Title ?? string.Empty,

                Content =
                            bookmark.Article?.Content ?? string.Empty
            };
        }
    }

}
