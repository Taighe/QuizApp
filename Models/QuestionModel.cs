using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class QuestionModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Question { get; set; }

        public ICollection<OptionModel> OptionModel { get; set; }

        public int Answer { get; set; }
    }
}
