namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {

        int ProductCountByEmployeeID(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();

    }
}
