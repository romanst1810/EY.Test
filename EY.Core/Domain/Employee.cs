using System;
using System.ComponentModel.DataAnnotations;

namespace EY.Core.Domain
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(15)]
        [RegularExpression("[a-zA-Z]+")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15)]
        [RegularExpression("[a-zA-Z]+")]
        public string LastName { get; set; }
       
        [Required]
        [StringLength(9)]
        [RegularExpression("[0-9]{9,9}")]
        public string SocialId { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; } 

        public string WorkDescription { get; set; }

        public Guid? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
