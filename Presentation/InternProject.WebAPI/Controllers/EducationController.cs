using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.WebAPI.Controllers;

public class EducationController: ControllerBase
{
    private readonly IEducationService _educationService;

    public EducationController(IEducationService educationService)
    {
        _educationService = educationService;
    }
    
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]  
    [HttpPost("AddEducation")]
    public async Task AddEducation([FromBody] EducationDto educationDto)
    {
        await _educationService.AddEducation(educationDto)!;
        
    }
    
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("UpdateEducation")]
    public async Task UpdateEducation([FromBody] EducationUpdateDto educationUpdateDto)
    {
        await  _educationService.UpdateEducation(educationUpdateDto);
        
    }

    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("DeleteEducation")]
    public async Task DeleteEducation([FromQuery] int id)
    {
        await _educationService.DeleteEducation(id);

    }

}