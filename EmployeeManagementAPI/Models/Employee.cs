using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI.Models
{
    [Table("employee")]
    public class Employee
    {

        [Key, Required]
        [Column("employee_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Column("firstname")]
        public string FirstName { get; set; }

        [Required]
        [Column("lastname")]
        public string LastName { get; set; }

        [Required]
        [Column("age")]
        public int Age { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

    }
}
