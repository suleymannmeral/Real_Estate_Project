using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Dtos.AboutUsSectionDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutUsSectionRepository
{
    public interface IAboutUsSectionRepository
    {
        Task<List<ResultAboutUsSectionDto>> GetAllAboutUsSection();
        Task<ResultAboutUsSectionDto> GetAboutUsSectionByID(int id);
        Task UpdateAboutUs(UpdateAboutUsSectionDto updateAboutUsSectionDto);
    }
}
