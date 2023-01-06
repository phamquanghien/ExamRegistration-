using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamRegistration.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamRegistration.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SubjectGroup>? SubjectGroup { get; set; }
        public DbSet<Subject>? Subject { get; set; }
    }
}