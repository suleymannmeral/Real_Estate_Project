﻿namespace RealEstate_Dapper_UI.Dtos.PopularLocationDto
{
    public class ResultPopularLocationDto
    {
        public int LocationID { get; set; }
        public string CityName { get; set; }
        public string ImageURL { get; set; }
        public int PropertyCount { get; set; }

    }
}
