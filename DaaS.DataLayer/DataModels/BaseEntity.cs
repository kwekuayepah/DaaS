using System;

namespace DaaS.DataLayer.DataModels
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}