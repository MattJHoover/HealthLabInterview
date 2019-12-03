using API.Models;
using System.Threading.Tasks;

namespace API.Database.Abstractions
{
    public interface IQuestionnaireAccess
    {
        Task<PatientQuestionnaire> GetQuestionnairesByClinic(string clinic);
    }
}