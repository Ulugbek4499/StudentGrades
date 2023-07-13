using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudentGrades.Application.Common.Models
{
    public class GradeDto
    {
        [JsonProperty("grade_id")]
        public Guid Id { get; set; }
        public int GradeNum { get; set; }
        public SubjectDto Subject { get; set; }
        public StudentDto Student { get; set; }
    }
}
