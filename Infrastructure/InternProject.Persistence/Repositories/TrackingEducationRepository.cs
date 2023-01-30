using InternProject.Application.Dto;
using InternProject.Application.Interfaces;
using InternProject.Domain.Entities;

namespace InternProject.Persistence.Repositories;

public class TrackingEducationRepository : ITrackingEducation
{

    private readonly IGenericRepository< AssignedEducation> _genericRepository;

    public TrackingEducationRepository(IGenericRepository<AssignedEducation> genericRepository)
    {
        _genericRepository = genericRepository;

    }

    public async Task AddFavoriteEducation(RequestAddFavoriteEducation requestAddFavoriteEducation)
    {
        var fav =  await _genericRepository.GetByIdAsync(requestAddFavoriteEducation.Id);
        fav.FavoriteEducation = true ;
        
        _genericRepository.Update( fav);

    }

    public async Task RemoveFavoriteEducation(int id )
    {
        // assignedEducation id
        var fav = await _genericRepository.GetByIdAsync(id);
        fav.FavoriteEducation = false;
        _genericRepository.Update( fav );
    }


    public async Task<ResponseWatchedEducationDto> WatchedEducation(WatchedEducationDto watchedEducationDto)
    {
        var assignEducation = await _genericRepository.GetByIdAsync(watchedEducationDto.id);
        assignEducation.CompletedEducation = true;
        await _genericRepository.Update(assignEducation);

        return new ResponseWatchedEducationDto()
        {
            AppUserId = assignEducation.AppUserId,
            EducationId = assignEducation.EducationId,
            CompletedEducation = assignEducation.CompletedEducation

        };

    }

   
    public async Task<AssignedEducationDto> AssignEducationToUser(AssignedEducationDto assignedEducationDto)
    {
        var assignEducation = new AssignedEducation()
        {
            AppUserId = assignedEducationDto.AppUserId,
            EducationId = assignedEducationDto.EducationId,

        };
        await _genericRepository.AddAsync(assignEducation);

        return new AssignedEducationDto()
        {
            AppUserId = assignEducation.AppUserId,
            EducationId = assignEducation.EducationId
        };
    }

    public async Task RemoveEducationFromUser(int id)
    {
        // assignedEducation id
        var remove = await _genericRepository.GetByIdAsync(id);

        remove.IsDeleted = true;
        _genericRepository.Remove( remove);
        
            
    }
}