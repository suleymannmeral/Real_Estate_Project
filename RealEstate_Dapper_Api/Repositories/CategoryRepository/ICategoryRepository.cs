using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {

        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(int id);

        void UpdateCategory(UpdateCategoryDto categoryDto);

      Task<GetByIDCategoryDto>GetCAtegory(int id);



    }
}
