using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace InternProject.WebAPI.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    
    // GET
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser( [FromBody] UserCreateRequestDto request)
    {
        var result = await _userRepository.AddUser(request);

        return Ok(result);
    }
    
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AuthenticateAsync([FromBody] UserLoginDto
        request)
    {
        var result = await _userRepository.Login(request);

        return Ok(result);
    }
    
    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task DeleteAsync([FromQuery] int id)
    {
       await _userRepository.DeleteUser(id);

    }
    
 
    [HttpPatch("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task UpdateAsync([FromBody] UserResponseDto userResponseDto)
    {
       await _userRepository.UpdateUser(userResponseDto);

    }
    
  /*
   
    
    [HttpGet("Kontrol")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> kontrol()
    {
        var asd = Request.HttpContext.User;
        await Task.Delay(1);
        return Ok();
    }
    */
}