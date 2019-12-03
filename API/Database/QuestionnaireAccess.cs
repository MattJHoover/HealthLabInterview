using API.Database.Abstractions;
using API.Configuration;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Database
{
    public class QuestionnaireAccess : IQuestionnaireAccess
    {
        public async Task<PatientQuestionnaire> GetQuestionnairesByClinic(string clinic)
        {
            using(var db = new DatabaseConfiguration())
            {
                return await db.Questionnaires.SingleAsync(q => q.Clinic == clinic);
            }
        }
    }
}