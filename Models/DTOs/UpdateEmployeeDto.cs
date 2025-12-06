using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models.DTOs
{
    public class UpdateEmployeeDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Education level is required")]
        public string EducationLevel { get; set; } = string.Empty;
    }
}
