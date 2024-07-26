namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultLast5ProductDto
    {
        public int ProductID { get; set; }
        public string Title { get; set; }

        public string CoverImage { get; set; }


        public decimal Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }
        public DateTime advertDate { get; set; }

    }
}
