using Microsoft.AspNetCore.Mvc;
using StudentGrades.Application.Common.Models;
using StudentGrades.Application.UseCases.Teachers.Commands.CreateTeacher;
using StudentGrades.Application.UseCases.Teachers.Commands.DeleteTeacher;
using StudentGrades.Application.UseCases.Teachers.Commands.UpdateTeacher;
using StudentGrades.Application.UseCases.Teachers.Queries.GetTeacher;
using StudentGrades.Application.UseCases.Teachers.Queries.GetTeachers;

namespace StudentGrades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async ValueTask<ActionResult<TeacherDto>> PostTeacherAsync(CreateTeacherCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<TeacherDto>> GetTeacherAsync(Guid TeacherId)
        {
            return await Mediator.Send(new GetTeacherQuery(TeacherId));
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<TeacherDto[]>> GetAllTeacher()
        {
            return await Mediator.Send(new GetTeachersQuery());
        }


        [HttpPut("[action]")]
        public async ValueTask<ActionResult<TeacherDto>> UpdateTeacherAsync(UpdateTeacherCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<TeacherDto>> DeleteTeacherAsync(Guid TeacherId)
        {
            return await Mediator.Send(new DeleteTeacherCommand(TeacherId));
        }
    }
}
