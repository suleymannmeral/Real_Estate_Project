using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContact();
        Task<List<ResultLast4ContactDto>> GetAllLast4Contact();
        Task CreateContact(CreateContactDto createContactDto);
        Task DeleteContact(int id);
        Task<GetByIdContactDto> GetByIdContact(int id);
    }
}
