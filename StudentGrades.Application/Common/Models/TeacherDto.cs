﻿using Newtonsoft.Json;

namespace StudentGrades.Application.Common.Models
{
    public class TeacherDto
    {
        [JsonProperty("teacher_id")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<SubjectDto> Subjects { get; set; }
    }
}
