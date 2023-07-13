using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudentGrades.Domain.Entities;

namespace StudentGrades.Application.Common.Models
{
    public class StudentDto
    {
        [JsonProperty("student_id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string StudentRegesterNumber { get; set; }
        public ICollection<GradeDto> Grades { get; set; }
    }
}