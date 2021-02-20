using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class OptionModel
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool Choice { get; set; }
    }
}
