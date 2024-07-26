
using RealEstate_Dapper_Api.Dtos.ToDoListDto;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository
{
    public interface IToDoListRepository
    {

        Task<List<ResultToDoListDto>> GetToDoListAsync();
        void CreateToDoList(CreateToDoListDto createToDoListDto);
        void UpdateServices(UpdateToDoListDto updateToDoListDto);
        Task<GetByIDToDoListDto> GetToDoListByID(int id);
        void DeleteToDoList(int id);


    }
}
