using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S7.Models
{
    public class Exam
    {
        public long Id { get; set; }
        [Required,Range(0,100)]

        public int Score { get; set; }

        public long StudentId { get; set; }
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}