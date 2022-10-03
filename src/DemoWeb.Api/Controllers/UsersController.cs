using DemoWeb.Api.Interfaces.Services;
using DemoWeb.Api.Utils;
using DemoWeb.Api.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWeb.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            this._service = service;
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm]UserCreateViewModel userCreateViewModel)
        {
            var result = await _service.CreateAsync(userCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        {
            var result = await _service.GetAllAsync(@params);
            return Ok(result);
        }

        [HttpGet("{id}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _service.GetAsync(id);
            return StatusCode(result.statusCode, result.statusCode == 200 ? result.userViewModel : result.message);
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] UserCreateViewModel userCreateViewModel)
        {
            var result = await _service.UpdateAsync(id, userCreateViewModel);
            return StatusCode(result.statusCode, result.message);
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _service.DeleteAsync(id);
            return StatusCode(result.statusCode, result.message);
        }
    }
}
