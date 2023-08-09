using System.ComponentModel.DataAnnotations;

namespace Todo_Asp_Mvc.Net.Models
{
    public class MessageEmail
    {
        [Required(ErrorMessage = "Le champ titre est requis.")]
        [MinLength(5,ErrorMessage = "Le nombre minimum de caractères n'est pas atteint.")]
        public string Titre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Le champ Message est requis.")]
        [MinLength(10,ErrorMessage = "Le nombre minimum de caractères n'est pas atteint.")]
        public string Message { get; set; }
    }
}