using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S7.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required, MinLength(8), MaxLength(150)]

        public string SubjectName { get; set; }

        [Required, MinLength(2), MaxLength(20)]

        public string SubjectCode { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Exam> exam { get; set; }
    }
}