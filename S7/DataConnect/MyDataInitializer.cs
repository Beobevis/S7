using S7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace S7.DataConnect
{
    public class MyDataInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {

            base.Seed(context);
            context.Students.AddRange(new List<Student>()
            {
                new Student
                {
                     Name="Huy123456",
                     Email="huy@gmail.com",
                    Address ="Ha Noi",
                },
                 new Student
                {
                     Name="Cuong12345",
                     Email="huy@gmail.com",
                    Address ="Ha Noi",
                },
                  new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                    new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                      new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                        new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                          new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                            new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                              new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                                new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                                  new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                                    new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
                                      new Student
                {
                     Name="Vietanh1234",
                     Email="huy@gmail.com",
                     Address ="Ha Noi",

                },
            });

            context.Subjects.AddRange(new List<Subject>()
            {
                new Subject
                {
                    SubjectName="MVC123456",
                    Description="MVC",
                    StartDate= new DateTime(2021,01,10),
                    EndDate = new DateTime(2023,2,10),
                    SubjectCode = "MVC123",
                },
                new Subject
                {
                    SubjectName="API123456",
                    Description="MVC",
                    StartDate= new DateTime(2021,01,10),
                    EndDate = new DateTime(2023,2,10),
                    SubjectCode = "MVC123",
                },
                new Subject
                {
                    SubjectName="REACT12345",
                    Description="MVC",
                    StartDate= new DateTime(2021,01,10),
                    EndDate = new DateTime(2023,2,10),
                    SubjectCode = "MVC123",
                },
            });

            context.SaveChanges();
        }
    }
}