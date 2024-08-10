using RealEstate_Dapper_Api.Dtos.AboutUsDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutUsRepository
{
    public interface IAboutUsRepository
    {
        Task<List<ResultAboutUsDto>> GetAllAboutUs();
        Task<ResultAboutUsDto>GetAboutUsByID(int id);
        Task UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto);

    }
}
