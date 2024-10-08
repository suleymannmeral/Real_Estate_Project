﻿using RealEstate_Dapper_Api.Dtos.ServicesDto;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDto;

namespace RealEstate_Dapper_Api.Repositories.ServicesRepository
{
    public interface IServicesRepository
    {
       
        Task <List<ResultServiceDto>> GetServicesAsync();
        Task CreateServices(CreateServicesDto createServicesDto);
        Task UpdateServices(UpdateServicesDto updateServicesDto);
        Task<GetByIDServicesDto> GetServicesWithID(int id);
        Task DeleteServices(int id );




    }
}
