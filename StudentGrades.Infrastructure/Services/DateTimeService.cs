using StudentGrades.Application.Common.Interfaces;

namespace StudentGrades.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
