using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClientApp.Database.Abstractions;
using ClientApp.Database.Models;
using ClientApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IForecastAccess _forecastAccess;
        private readonly IPatientAccess _PatientAccess;
        public HomeController(IForecastAccess forecastAccess, IPatientAccess patientAccess)
        {
            _forecastAccess = forecastAccess;
            _PatientAccess = patientAccess;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string clinic)
        {
            // If we were saving anything to the database this is where we would call the manager to do so.
            return RedirectToAction("Questionnaires", new { clinic });
        }

        [HttpGet]
        public async Task<IActionResult> WeatherReport(string zipcode)
        {
            WeatherForecast forecast = await _forecastAccess.GetForecastForZipcode(zipcode);

            WeatherReportViewModel toRet = new WeatherReportViewModel()
            {
                Description = forecast.Summary,
                TemperatureC = forecast.TemperatureC.ToString(),
                TemperatureF = forecast.TemperatureF.ToString(),
                Zipcode = forecast.Zipcode
            };

            if (forecast.TemperatureC < 5)
            {
                toRet.TemperatureClass = "freezing";
            }
            else if (forecast.TemperatureC < 15)
            {
                toRet.TemperatureClass = "cold";
            }
            else
            {
                toRet.TemperatureClass = "warm";
            }

            return View(toRet);
        }

        public async Task<IActionResult> Questionnaires(string clinic)
        {
            PatientQuestionnaire questionnaire = await _PatientAccess.GetQuestionnairesForClinic(clinic);
            PatientQuestionnaireViewModel toRet = new PatientQuestionnaireViewModel()
            {
                Name = questionnaire.Name,
                Description = questionnaire.Summary,
                Clinic = questionnaire.Clinic
            };

            return View(toRet);
        }
    }
}
