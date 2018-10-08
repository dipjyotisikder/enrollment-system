using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollMent_00.Models
{
    public class Course
    {
        [Required]
        [Display(Name = "Course Code")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseID { get; set; }
        [Required]
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        [Display(Name = "Credit Hour")]
        public float CreditHour { get; set; }
        [Required]
        public int Semester { get; set; }
    }
}
