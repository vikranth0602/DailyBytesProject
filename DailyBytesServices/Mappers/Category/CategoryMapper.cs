using DailyBytesDAL.Models;
using DailyBytesServices.DTOs.Category;

namespace DailyBytesServices.Mappers.Category
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToCategoryDTO(
            this DailyBytesDAL.Models.Category category
        )
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}