using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollMent_00.Models
{
    public class Enrollment
    {
        
        public int ID { get; set; }
        [Required]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Semester { get; set; }

        public bool IsPaid { get; set; }
        [Required]
        public bool Regular { get; set; }

        public Transaction Transaction { get; set; }

        public ICollection<Course> Courses { get; set; }

        public Student Student { get; set; }
    }
}
