namespace InternProject.Application.Dto;

public class ResponseWatchedEducationDto
{
    public int AppUserId { get; set; }
    public int EducationId { get; set; }
    public bool CompletedEducation { get; set; }
}