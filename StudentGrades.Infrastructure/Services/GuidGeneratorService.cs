using StudentGrades.Application.Common.Interfaces;

namespace StudentGrades.Infrastructure.Services
{
    public class GuidGeneratorService : IGuidGenerator
    {
        public Guid Guid => Guid.NewGuid();
    }
}
