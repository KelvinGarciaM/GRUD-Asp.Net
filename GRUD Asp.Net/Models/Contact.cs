using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GRUD_Asp.Net.Models
{
    public class Contact
    {
        [Key]//Especificamos que es una llave primaria, pero solo con el hecho de poner Id o Id con nombre ya es valido
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es Obligatorio, no sea yegua!")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Telefono es Obligatorio, no sea yegua!")]
        [Display(Name="Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Celular es Obligatorio, no sea yegua!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El Emails es Obligatorio, no sea yegua!")]
        public string Email { get; set; }

        public DateTime FechaCreacion{ get; set; } 


        
    }
}
