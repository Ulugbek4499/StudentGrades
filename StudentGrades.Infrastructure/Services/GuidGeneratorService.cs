using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGrades.Application.Common.Interfaces;

namespace StudentGrades.Infrastructure.Services
{
    public class GuidGeneratorService : IGuidGenerator
    {
        public Guid Guid => Guid.NewGuid();
    }
}
