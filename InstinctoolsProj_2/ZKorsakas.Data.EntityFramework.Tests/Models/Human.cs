﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZKorsakas.Data.EntityFramework.Tests.Models
{
    [Table("Human")]
    public class Human : Entity
    {
        [Required]
        public string Name { set; get; }
    }
}
