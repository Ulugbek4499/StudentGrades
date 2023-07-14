using Newtonsoft.Json;

namespace StudentGrades.Application.Common.Models
{
    public class GradeDto
    {
        [JsonProperty("grade_id")]
        public Guid Id { get; set; }
        public int Score { get; set; }
        //public SubjectDto Subject { get; set; }
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
        //public StudentDto Student { get; set; }
    }
}
