using S7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S7.DataConnect
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyConnectionStrings") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Exam> Exams { get; set; }
    }
}