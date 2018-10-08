using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollMent_00.Models
{
    [Table("Students")]
    public class Student
    {
        //private IHostingEnvironment env;

        
        //public Student(IHostingEnvironment _env)
        //{
        //    env = _env;
        //}
        public Student()
        {

        }

        [Required]
        [Display(Name = "Student ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Registration Number")]
        public int RegNo { get; set; }
        [Required]
        public string Session { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        [Display(Name = "Father's Name")]
        public string FathersName { get; set; }
        [Required]
        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }
        [Required]
        [Display(Name = "Parmanent Address")]
        public string Address { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public bool Tribe { get; set; }
        [Required]
        public string HallName { get; set; }
        [Required]
        [Display(Name = "Hall Border Number")]
        public int BorderNo { get; set; }
        [Required]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }



        //public string GetUrl(IFormFile img ) {

        //    if (img != null)
        //    {
        //        var fileName = Path.Combine(env.WebRootPath, Path.GetFileName(img.FileName));
        //        img.CopyTo(new FileStream(fileName, FileMode.Create));
        //        ImageUrl = fileName;
        //    }
        //    return ImageUrl ;
        //}


    }
}
