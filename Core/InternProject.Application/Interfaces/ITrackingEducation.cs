using InternProject.Application.Dto;
using InternProject.Domain.Entities;

namespace InternProject.Application.Interfaces;

public interface ITrackingEducation
{
    Task AddFavoriteEducation( RequestAddFavoriteEducation favoriteEducationDto);
    
    Task RemoveFavoriteEducation(int id);
    
    Task < ResponseWatchedEducationDto > WatchedEducation( WatchedEducationDto watchedEducationDto);
    
    Task< AssignedEducationDto> AssignEducationToUser( AssignedEducationDto assignedEducationDto);
    
    Task RemoveEducationFromUser( int id );
    
}