using Microsoft.AspNetCore.Mvc;
using StudentGrades.Application.Common.Models;
using StudentGrades.Application.UseCases.Grades.Commands.CreateGrade;
using StudentGrades.Application.UseCases.Grades.Commands.DeleteGrade;
using StudentGrades.Application.UseCases.Grades.Commands.UpdateGrade;
using StudentGrades.Application.UseCases.Grades.Queries.GetGrade;
using StudentGrades.Application.UseCases.Grades.Queries.GetGrades;

namespace StudentGrades.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async ValueTask<ActionResult<GradeDto>> PostGradeAsync(CreateGradeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<GradeDto>> GetGradeAsync(Guid GradeId)
        {
            return await Mediator.Send(new GetGradeQuery(GradeId));
        }

        [HttpGet("[action]")]
        public async ValueTask<ActionResult<GradeDto[]>> GetAllGrade()
        {
            return await Mediator.Send(new GetGradesQuery());
        }

        [HttpPut("[action]")]
        public async ValueTask<ActionResult<GradeDto>> UpdateGradeAsync(UpdateGradeCommand command)
        {
            return await Mediator.Send(command);
        }


        [HttpDelete("[action]")]
        public async ValueTask<ActionResult<GradeDto>> DeleteGradeAsync(Guid GradeId)
        {
            return await Mediator.Send(new DeleteGradeCommand(GradeId));
        }
    }
}
