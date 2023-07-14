using Microsoft.EntityFrameworkCore;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
