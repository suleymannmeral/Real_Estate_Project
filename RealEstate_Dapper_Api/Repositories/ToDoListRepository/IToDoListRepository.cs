
using RealEstate_Dapper_Api.Dtos.ToDoListDto;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {

        Task<List<ResultToDoListDto>> GetToDoListAsync();
        Task CreateToDoList(CreateToDoListDto createToDoListDto);
        Task UpdateServices(UpdateToDoListDto updateToDoListDto);
        Task<GetByIDToDoListDto> GetToDoListByID(int id);
        Task DeleteToDoList(int id);


    }
}
