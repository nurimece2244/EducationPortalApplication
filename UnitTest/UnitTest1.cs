
using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;
using InternProject.WebAPI.Controllers;
using Moq;

namespace UnitTest;

public class UnitTest1
{
   private readonly Mock<IEducationCategory > _mock;
   private readonly EducationCategoryController _educationCategoryController;
   EducationCategoryDto educationCategoryDto;

   public UnitTest1()
   {
      _mock = new Mock<IEducationCategory>();
      _educationCategoryController = new EducationCategoryController(_mock.Object);

      educationCategoryDto = new EducationCategoryDto()
      {
            Name = "Udemy den inciler"
      };

   }
    [Fact]
   public async void AddCategory()

    {
        _mock.Setup(x => x.AddEducationCategory(educationCategoryDto)).ReturnsAsync(educationCategoryDto);
       
  

   }

}
