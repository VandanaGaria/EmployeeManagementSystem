using System.ComponentModel.DataAnnotations;

namespace employeeManagementAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ?FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string ?LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string ?Address { get; set; }

        [Required]
        [StringLength(15)]
        public string ?Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string ?Email { get; set; }

        [Required]
        [StringLength(50)]
        public string? Designation { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Range(0,double.MaxValue,ErrorMessage="Salary must be positive value !")]
        public decimal Salary  { get; set; }
    }
}
