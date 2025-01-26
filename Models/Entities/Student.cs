using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression(
            @"^\(\d{3}\) \d{3}-\d{4}$",
            ErrorMessage = "Invalid phone number format. Use (123) 456-7890"
        )]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(150)]
        public string? Address { get; set; }

        public bool Subscribed { get; set; }
    }
}
