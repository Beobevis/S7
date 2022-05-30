using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S7.Models
{
    public class Student
    {
        public long StudentId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 8)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<Exam> exam { get; set; }
    }
}