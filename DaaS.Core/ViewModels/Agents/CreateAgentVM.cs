using System.ComponentModel.DataAnnotations;

namespace DaaS.Core.ViewModels.Agents
{
    public class CreateAgentVM
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string MotorNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string CountryCode { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountProvider { get; set; }
        public string AccountCode { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }
}