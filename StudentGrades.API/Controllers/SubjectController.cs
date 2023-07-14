using Microsoft.AspNetCore.Mvc;
using StudentGrades.Application.Common.Models;
using StudentGrades.Application.UseCases.Subjects.Commands.CreateSubject;
using StudentGrades.Application.UseCases.Subjects.Commands.DeleteSubject;
using StudentGrades.Application.UseCases.Subjects.Commands.UpdateSubject;
using StudentGrades.Application.UseCases.Subjects.Queries.GetSubject;
using StudentGrades.Application.UseCases.Subjects.Queries.GetSubjects;

namespace StudentGrades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async ValueTask<ActionResult<SubjectDto>> PostSubjectAsync(CreateSubjectCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<SubjectDto>> GetSubjectAsync(Guid SubjectId)
        {
            return await Mediator.Send(new GetSubjectQuery(SubjectId));
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<SubjectDto[]>> GetAllSubject()
        {
            return await Mediator.Send(new GetSubjectsQuery());
        }


        [HttpPut("[action]")]
        public async ValueTask<ActionResult<SubjectDto>> UpdateSubjectAsync(UpdateSubjectCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<SubjectDto>> DeleteSubjectAsync(Guid SubjectId)
        {
            return await Mediator.Send(new DeleteSubjectCommand(SubjectId));
        }
    }
}
