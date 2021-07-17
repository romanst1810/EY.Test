using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EY.Core.Domain
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime DateUpdate { get; set; } = DateTime.Now;

        public string UserCreate { get; set; }
       
        [Required]
        [StringLength(15)]
        [RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string WorkStatus { get; set; } = "Works";
        public List<Employee> Employers { get; set; } = new List<Employee>();
    }
}
