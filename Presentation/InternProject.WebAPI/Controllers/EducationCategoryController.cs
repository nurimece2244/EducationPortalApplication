using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.WebAPI.Controllers;

public class EducationCategoryController : ControllerBase
{
    private readonly IEducationCategory _educationCategory;


    public EducationCategoryController(IEducationCategory educationCategory)
    {
        _educationCategory = educationCategory;
    }
    
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("AddCategory")]
    public async Task AddCategory([FromBody] EducationCategoryDto educationCategoryDto)
    {
        await _educationCategory.AddEducationCategory(educationCategoryDto);
     
    }
    
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpPost("UpdateCategory")]
    public void UpdateCategory([FromBody] EducationCategoryUpdateDto educationCategoryUpdateDto)
    {
        _educationCategory.UpdateEducationCategory(educationCategoryUpdateDto);

    }
    [Authorize( Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [HttpDelete("DeleteCategory")]
    public void DeleteCategory([FromQuery] int id)
    {
        _educationCategory.DeleteEducationCategory(id);

    }

}