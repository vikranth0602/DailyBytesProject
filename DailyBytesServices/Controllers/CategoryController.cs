using DailyBytesDAL.Repositories.Interfaces;
using DailyBytesServices.DTOs;
using DailyBytesServices.DTOs.Category;
using DailyBytesServices.Helpers;
using DailyBytesServices.Mappers.Category;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    //GetCategory
    #region-GetCategory
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       
            var categories = await _categoryRepository.GetAllAsync();

            var result = categories
                        .Select(c => c.ToCategoryDTO())
                        .ToList();

            return Ok(
                new ApiResponse<List<CategoryDTO>>
                {
                    Success = true,
                    Message = "Categories fetched",
                    Data = result
                }
            );
      
    }
    #endregion

}