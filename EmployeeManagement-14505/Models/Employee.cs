using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementFull.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required] public string FirstName { get; set; } = null!;
        [Required] public string LastName { get; set; } = null!;
        [Required] public string Email { get; set; } = null!;
        [Required] public string PhoneNumber { get; set; } = null!;
        [Required] public string Department { get; set; } = null!;
        [Required] public string Country { get; set; } = null!;
        [Required] public string Address { get; set; } = null!;
        [Required] public string Position { get; set; } = null!; 
        [Required] public DateTime BirthDate { get; set; }
    }
}