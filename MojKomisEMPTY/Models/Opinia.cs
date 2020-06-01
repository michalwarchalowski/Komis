using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MojKomisEMPTY.Models
{
    public class Opinia
    {
        [BindNever]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nazwa uzytkownika jest wymagana")]
        [StringLength(100,ErrorMessage ="Za dlugo nazwa")]
        public string NazwaUzytkownika { get; set; }
        [Required(ErrorMessage = "Email jest wymagana")]
        [StringLength(30, ErrorMessage = "Za dlugi email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wiadomosc jest wymagana")]
        [StringLength(15, ErrorMessage = "Za dlugi email")]
        public string Wiadomosc { get; set; }
        public bool OczekujOdpowiedzi { get; set; }
    }
}
