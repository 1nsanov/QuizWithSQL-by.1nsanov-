using System.Data.Entity;

namespace QuizWithSQL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base ("DatabaseContext")
        {

        }

        public DbSet<People> Humans { get; set; }
    }
}
