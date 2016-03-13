﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YueShanp.Models
{
    public class Item : BaseEntity<int>
    {
        [Required]
        [DisplayName("名稱")]
        public string Name { get; set; }

        [Required]
        [DisplayName("單價")]
        public decimal UnitPrice { get; set; }

        [Required]
        [DisplayName("種類")]
        public ItemType ItemType { get; set; }
    }
}