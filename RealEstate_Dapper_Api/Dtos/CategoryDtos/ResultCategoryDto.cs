namespace RealEstate_Dapper_Api.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        // Nesnelerin Databasede Oluşturduğumuz Sütun Adıyla Aynı Olmasına Dikkat Edeceğiz. Birer Data Transfer Object (DTO) Oluşturduk
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } 

        public bool  CategoryStatus { get; set; }



    }
}
