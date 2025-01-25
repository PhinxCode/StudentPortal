using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(150)]
        public string? Address { get; set; }

        public bool Subscribed { get; set; }
    }
}
