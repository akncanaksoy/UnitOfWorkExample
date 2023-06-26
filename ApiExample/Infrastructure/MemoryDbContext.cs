using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiExample.Infrastructure
{
	public class MemoryDbContext:DbContext
	{
		public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Deneme");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
      
           modelBuilder.Entity<Student>().HasData(
           new Student { Id = 1, Name = "John", LastName = "Doe", Subject = "Math" },
           new Student { Id = 2, Name = "Jane", LastName = "Smith", Subject = "Science" },
           new Student { Id = 3, Name = "Hüs", LastName = "Man", Subject = "Science" },
           new Student { Id = 4, Name = "Berkay", LastName = "CT", Subject = "Electrics" }
                );
        }

      
    }

     public class BaseEntity
	{
		public int Id { get; set; }
		
	}

    public class Student:BaseEntity
    {
        public string Name { get; set; }
		public string LastName { get; set; }
		public string Subject { get; set; }


        public Student(int id,string name ,string lastName,string subject)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Subject = subject;
        }

            public Student()
            {

            }
        

    }

    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Departman { get; set; }


        public Teacher(int id,string name, string lastName, string departman)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Departman = departman;
        }

            public Teacher()
            {

            }

    }


}

