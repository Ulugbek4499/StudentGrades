using Microsoft.AspNetCore.Mvc;
using StudentGrades.Application.Common.Models;
using StudentGrades.Application.UseCases.Students.Commands.CreateStudent;
using StudentGrades.Application.UseCases.Students.Commands.DeleteStudent;
using StudentGrades.Application.UseCases.Students.Commands.UpdateStudent;
using StudentGrades.Application.UseCases.Students.Queries.GetStudent;
using StudentGrades.Application.UseCases.Students.Queries.GetStudents;

namespace StudentGrades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async ValueTask<ActionResult<StudentDto>> PostStudentAsync(CreateStudentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<StudentDto>> GetStudentAsync(Guid StudentId)
        {
            return await Mediator.Send(new GetStudentQuery(StudentId));
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<StudentDto[]>> GetAllStudent()
        {
            return await Mediator.Send(new GetStudentsQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<ActionResult<StudentDto>> UpdateStudentAsync(UpdateStudentCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<StudentDto>> DeleteStudentAsync(Guid StudentId)
        {
            return await Mediator.Send(new DeleteStudentCommand(StudentId));
        }
    }
}
