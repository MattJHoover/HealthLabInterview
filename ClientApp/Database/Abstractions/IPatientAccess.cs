using ClientApp.Database.Models;
using System.Threading.Tasks;

namespace ClientApp.Database.Abstractions
{
    public interface IPatientAccess
    {
        Task<PatientQuestionnaire> GetQuestionnairesForClinic(string clinic);
    }
}