﻿namespace RealEstate_Dapper_Api.Dtos.EmployeeDtos
{
    public class GetByIDEmployeeDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string ImgUrl { get; set; }
        public bool Status { get; set; }
    }
}
