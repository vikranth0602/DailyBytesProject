using DailyBytesServices.DTOs.Article;
using DailyBytesServices.Helpers;
using DailyBytesServices.Mappers.Article;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;

    public ArticleController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

   
    #region Get All Articles
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       
            var article = await _articleRepository.GetAllAsync();

            var result = article.Select(a => a.ToArticleListDTO());

            return Ok(
                new ApiResponse<IEnumerable<ArticleListDTO>>
                {
                    Success = true,
                    Message = "Articles fetched successfully",
                    Data = result
                }
            );
    }
    #endregion

    #region Get By Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
     
            var article = await _articleRepository.GetByIdAsync(id);

            if (article == null)
            {
                return NotFound(
                    new ApiResponse<object>
                    {
                        Success = false,
                        Message = "Article not found",
                        Data = null
                    }
                );
            }

            var result = article.ToArticleDetailDTO();

            return Ok(
                new ApiResponse<ArticleDetailDTO>
                {
                    Success = true,
                    Message = "Article fetched successfully",
                    Data = result
                }
            );
   
    }

    #endregion

}