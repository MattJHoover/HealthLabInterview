using System.Threading.Tasks;
using API.Database.Abstractions;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntervieweeProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientQuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireAccess _QuestionnaireAccess;
        public PatientQuestionnaireController(IQuestionnaireAccess questionnaireAccess)
        {
            _QuestionnaireAccess = questionnaireAccess;
        }

        [HttpGet("GetByClinic/{clinic}")]
        public async Task<IActionResult> GetByClinicAsync([FromRoute] string clinic)
        {
            PatientQuestionnaire questionnaire = await _QuestionnaireAccess.GetQuestionnairesByClinic(clinic);
            return new JsonResult(questionnaire);
        }
    }
}