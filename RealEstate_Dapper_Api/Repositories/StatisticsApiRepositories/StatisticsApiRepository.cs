using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsApiRepositories
{
    public class StatisticsApiRepository : IStatisticsApiRepository
    {
        private readonly Context _context;
        public StatisticsApiRepository(Context context)
        {
            _context = context;
        }
        public  int ActiveCategoryCount()
        {

            string query = "Select Count(*) From Category where CategoryStatus=1 ";
            using (var connection = _context.CreateConnection())
            {
                var values =  connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Employee where Status=1 ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }

        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product where Title like '%Daire%' ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AvgProductByRent()
        {
            string query = "Select Avg(Price) From Product where Type='Rent'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public decimal AvgProductBySale()
        {
            string query = "Select Avg(Price) From Product where Type='Sale'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public int AvgRoomCount()
        {
            string query = "Select Avg(RoomCount) From ProductDetails ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) From Category ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProduct()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product  inner join Category  on Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProduct()
        {
            string query = "Select top(1) City,Count(*) as 'İlan_Sayısı' From Product Group By City order by İlan_Sayısı Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }

        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProduct()
        {
            string query = "Select top(1) Name,Count(*) 'product_count' From Product Inner Join Employee On Product.UserID=Employee.EmployeeID Group By Name order by product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price From Product Order By ProductID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product ";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

    }
}
