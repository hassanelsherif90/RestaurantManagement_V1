﻿namespace RestaurantManagement.Core.Models.Data
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}