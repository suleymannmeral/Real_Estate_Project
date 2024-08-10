﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductWithSearchListDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public string CoverImage { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
        public string categoryName { get; set; }
        public string categoryID { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime advertDate { get; set; }
        public string SlugUrl { get; set; }
        public int UserID { get; set; }


    }
}
