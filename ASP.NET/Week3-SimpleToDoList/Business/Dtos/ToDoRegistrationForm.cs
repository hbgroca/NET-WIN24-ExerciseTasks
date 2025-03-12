using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class ToDoRegistrationForm
    {
        [Display(Name = "Description", Prompt = "Add something to list....")]
        [Required(ErrorMessage = "Description is required, stupid!")]
        public string Title { get; set; } = null!;
    }
}
