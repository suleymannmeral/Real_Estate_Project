﻿using RealEstate_Dapper_Api.Dtos.ContactUsDto;

namespace RealEstate_Dapper_Api.Repositories.ContactUsRepositories
{
    public interface IContactUsRepository
    {
        Task<List<ResultContactUsDto>> GetContactUsInfo();
        Task <ResultContactUsDto> GetContactUsById(int id);
        Task  UpdateContactUs(UpdateContactUsDto updateContactUs);

    }
}
