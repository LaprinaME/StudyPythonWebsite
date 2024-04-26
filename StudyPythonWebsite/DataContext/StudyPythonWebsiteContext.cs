using Microsoft.EntityFrameworkCore;
using StudyPythonWebsite.Models;

namespace StudyPythonWebsite.DataContext
{
    public class StudyPythonWebsiteContext : DbContext
    {
        public StudyPythonWebsiteContext(DbContextOptions<StudyPythonWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Test> Tests { get; set; }

    }
}
