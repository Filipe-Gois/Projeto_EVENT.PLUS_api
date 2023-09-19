using System.ComponentModel.DataAnnotations;
using webapi.event_.tarde.Contexts;

namespace webapi.event_.tarde.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha é obrigatória!")]
        public string? Senha { get; set; }



    }
}
