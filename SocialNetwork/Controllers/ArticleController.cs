using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.DTOs;
using SocialNetwork.Models;
using SocialNetwork.Services;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new
                {
                    StatusCode = 200,
                    data = _articleService.Get(),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(new
                {
                    StatusCode = 200,
                    data = _articleService.GetById(id),
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ArticleDto dto)
        {
            Article? article = null;
            try
            {
                article = await _articleService.Create(dto);
                return Ok(new
                {
                    StatusCode = 200,
                    data = article,
                    message = String.Format("Create new article {0} successfully", dto.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = article,
                    message = ex.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _articleService.RemoveAsync(id);
                return Ok(new
                {
                    StatusCode = 200,
                    message = String.Format("Delete the article {0} successfully", id)
                });
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ArticleDto dto)
        {
            Article? article = null;
            try
            {
                article = await _articleService.Update(dto);
                return Ok(new
                {
                    StatusCode = 200,
                    data = article,
                    message = String.Format("Update new article {0} successfully", dto.Id)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = article,
                    message = ex.Message
                });
            }
        }
    }
}
