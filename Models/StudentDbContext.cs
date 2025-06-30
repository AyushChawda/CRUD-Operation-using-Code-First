using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CRUD_Operation_using_Code_First.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Student> Student_List { get; set; }
    }
}
