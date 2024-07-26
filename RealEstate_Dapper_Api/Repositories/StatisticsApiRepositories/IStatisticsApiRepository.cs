namespace RealEstate_Dapper_Api.Repositories.StatisticsApiRepositories
{
    public interface IStatisticsApiRepository
    {
        int CategoryCount();
        int PassiveCategoryCount();
        int ActiveCategoryCount();
        int ActiveEmployeeCount();

        int ProductCount();
        int ApartmentCount();
        string EmployeeNameByMaxProduct();
        string CategoryNameByMaxProduct();

        decimal AvgProductByRent();
        decimal AvgProductBySale();
        string CityNameByMaxProduct();
        int DifferentCityCount();
        decimal LastProductPrice();
        string NewestBuildingYear();
        string OldestBuildingYear();

        int AvgRoomCount();









    }
}
