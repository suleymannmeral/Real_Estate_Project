﻿namespace RealEstate_Dapper_Api.Dtos.PopularLocationDto
{
    public class DeletePopularLocationDto
    {
        public int LocationID { get; set; }
        public string CityName { get; set; }
        public string ImageURL { get; set; }
        public int PropertyCount { get; set; }

    }
}
