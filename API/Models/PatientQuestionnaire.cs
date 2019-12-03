using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class PatientQuestionnaire
    {
        [Key]
        public int PatientQuestionnaireId { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public string Clinic { get; set; }
    }
}