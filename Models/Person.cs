using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo_Asp_Mvc.Net.Models
{
    [Table("persons")]
    public class Person : CommonModel
    {
        [Required(ErrorMessage = "Prenom is required !")]
        [StringLength(2,ErrorMessage = "Min 2 caracters is required for prenom !")]
        public string Prenom { get; set; }
        [Required(ErrorMessage = "Nom is required !")]
        [StringLength(2, ErrorMessage = "Min 2 caracters is required for nom !")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Date de naissance is required !")]
        [DataType(DataType.DateTime)]
        public DateTime DateNaissance { get; set; }
        [Required(ErrorMessage = "Adresse is required !")]
        public int AdresseId { get; set; }
        [ForeignKey("AdresseId")]
        [JsonIgnore]
        public Adresse Adresse { set; get; } = null;
    }
}