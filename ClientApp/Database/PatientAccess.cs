using ClientApp.Database.Abstractions;
using ClientApp.Database.Models;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientApp.Database
{
    public class PatientAccess : IPatientAccess
    {
        private readonly IHttpClientFactory _clientFactory;

        public PatientAccess(IHttpClientFactory factory)
        {
            _clientFactory = factory;
        }

        public async Task<PatientQuestionnaire> GetQuestionnairesForClinic(string clinic)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:5001/PatientQuestionnaire/GetByClinic/{clinic}");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            PatientQuestionnaire toRet;

            if(response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                toRet = await JsonSerializer.DeserializeAsync<PatientQuestionnaire>(stream);
            } else
            {
                throw new Exception("Questionnaires request failed");
            }
            return toRet;
        }
    }
}