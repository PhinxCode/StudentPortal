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
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        public bool Subscribed { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        [MaxLength(30)]
        public string Major { get; set; } = string.Empty;

        [Precision(4, 2)] // Corrección de precisión válida
        public double GPA { get; set; }

        [MaxLength(30)]
        public string StudentIdNumber { get; set; } = string.Empty;

        [MaxLength(30)]
        public string EmergencyContact { get; set; } = string.Empty;

        [MaxLength(30)]
        public string EmergencyPhone { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [MaxLength(30)]
        public string Gender { get; set; } = string.Empty;

        [MaxLength(30)]
        public string Nationality { get; set; } = string.Empty;

        // Almacenamos cursos como una lista separada por comas
        public string EnrolledCourses { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Name}, Email: {Email}, Teléfono: {Phone}, Carrera: {Major}, Inscrito: {IsActive}";
        }
    }
}
