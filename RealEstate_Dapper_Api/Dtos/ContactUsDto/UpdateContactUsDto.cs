namespace RealEstate_Dapper_Api.Dtos.ContactUsDto
{
    public class UpdateContactUsDto
    {
        public int ContactUsId { get; set; }
        public string OfficeAdress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Location { get; set; }
    }
}
