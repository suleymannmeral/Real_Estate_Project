namespace RealEstate_Dapper_Api.Tools
{
   
        public class GetCheckAppUserViewModel
        {
            public int ID { get; set; }
            public string Username { get; set; }
            public int RoleID { get; set; }  // Role ID as integer
            public bool IsExist { get; set; }
        }
    

}
