using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BashNipi6.Models
{
   
        public class ProjectsContext : DbContext
        {
        public DbSet<Project> Projects { get; set; }
        public DbSet<objectB> objectBs { get; set; }
       
        public ProjectsContext(DbContextOptions<ProjectsContext> options)
                : base(options)
            {
                Database.EnsureCreated();
            }

        public ProjectsContext()
        {
        }


    }
}
