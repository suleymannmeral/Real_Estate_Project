using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AboutUsRepository;
using RealEstate_Dapper_Api.Repositories.AboutUsSectionRepository;
using RealEstate_Dapper_Api.Repositories.AboutUsWhyUsRepository;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepositories;
using RealEstate_Dapper_Api.Repositories.ContactUsRepositories;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.Last5ProductRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashBoardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.ProductImageRepositories;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;
using RealEstate_Dapper_Api.Repositories.ServicesRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsApiRepositories;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepositories;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDepencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreRepository, WhoWeAreRepository>();
           services.AddTransient<IServicesRepository, ServicesRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStatisticsApiRepository, StatisticsApiRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepositories, ChartRepositories>();
            services.AddTransient<ILast5ProductRepository, Last5ProductRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
          services.AddTransient<IProductImageRepository, ProductImageRepository>();
           services.AddTransient<IAppUserRepository, AppUserRepository>();
           services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
          services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
          services.AddTransient<IContactUsRepository , ContactUsRepository>();
          services.AddTransient<IAboutUsRepository , AboutUsRepository>();
          services.AddTransient<IAboutUsSectionRepository , AboutUsSectionRepository>();
          services.AddTransient<IAboutUsWhyUsRepository , AboutUsWhyRepository>();
        }
    }
}
