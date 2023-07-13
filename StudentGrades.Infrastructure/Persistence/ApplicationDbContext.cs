using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StudentGrades.Application.Common.Interfaces;
using StudentGrades.Domain.Entities;
using StudentGrades.Infrastructure.Persistence.Interceptors;

namespace StudentGrades.Infrastructure.Persistence
{

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private readonly AuditableEntitySaveChangesInterceptor _interceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor interceptor)
            : base(options)
        {
            _options = options;
            _interceptor = interceptor;
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
        }
    }
}
