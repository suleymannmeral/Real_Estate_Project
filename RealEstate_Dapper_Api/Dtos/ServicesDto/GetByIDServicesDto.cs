﻿namespace RealEstate_Dapper_Api.Dtos.ServicesDto
{
    public class GetByIDServicesDto
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }

    }
}
