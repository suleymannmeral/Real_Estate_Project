﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int productID { get; set; }
        public string title { get; set; }
        public string CoverImage { get; set; }
        public decimal price { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
        public string categoryName { get; set; }

    }
}