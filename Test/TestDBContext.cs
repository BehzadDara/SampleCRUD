using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test
{
    public class TestDBContext : DbContext
    {
        public DbSet<TestModel>? TestModels { get; set; }

        public TestDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().HasKey(x => x.Id);
        }
    }
}
