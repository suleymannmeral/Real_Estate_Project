
using RealEstate_Dapper_Api.Dtos.AboutUsSectionDtos;
using RealEstate_Dapper_Api.Dtos.AboutUsWhyUsDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutUsWhyUsRepository
{
    public interface IAboutUsWhyUsRepository
    {


        Task<List<ResultAboutUsWhyUsDto>> GetAllAboutUsWhyUs();
        Task<ResultAboutUsWhyUsDto> GetAboutUsWhyUsById(int id);
        Task UpdateAboutUsWhyUs(UpdateAboutUsWhyUsDto updateAboutUsWhyUsDto);
    }
}
