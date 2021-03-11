namespace DaaS.DataLayer.DataModels
{
    public class Agent:BaseEntity
    {
        public string Fullname { get; set; }
        public string ImageUrl { get; set; }
        public string MotorNumber { get; set; }
        public string MobileNumber { get; set; }
        public string CountryCode { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountProvider { get; set; }
        public string AccountCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        
    }
}