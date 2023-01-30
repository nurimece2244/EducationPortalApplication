using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.WebAPI.Controllers;

public class AssignedEducationController : ControllerBase
{
    private readonly ITrackingEducation _trackingEducation;

    public AssignedEducationController(ITrackingEducation trackingEducation)
    {
        _trackingEducation = trackingEducation;
    }
    
    [Authorize( Roles = "User, TeamLead, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("AddFavoriteEducation")]
    public void AddFavoriteEducation([FromQuery] RequestAddFavoriteEducation favoriteEducationDto)
    {
         _trackingEducation.AddFavoriteEducation(favoriteEducationDto);
        
    }
    
    [Authorize( Roles = "User, TeamLead, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("RemoveFavoriteEducation")]
    public void RemoveFavoriteEducation([FromQuery] int id)
    {
        _trackingEducation.RemoveFavoriteEducation(id);

        
    }
    
    [Authorize( Roles = "User, TeamLead, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("CompletedEducation")]
    public Task<ResponseWatchedEducationDto> WatchedEducation([FromBody] WatchedEducationDto watchedEducationDto)
    {
        var result= _trackingEducation.WatchedEducation(watchedEducationDto);

        return result;
    }
    
    [Authorize( Roles = "TeamLead, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("AssignEducationToUser")]
    public Task<AssignedEducationDto> AssignEducationToUser([FromBody] AssignedEducationDto assignedEducationDto)
    {
        var result= _trackingEducation.AssignEducationToUser(assignedEducationDto);

        return result;
    }
    
    [Authorize( Roles = "TeamLead, Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("RemoveEducationFromUser")]
    public void RemoveEducationFromUser([FromQuery] int id)
    {
        _trackingEducation.RemoveEducationFromUser(id);

        
    }
    
    
}