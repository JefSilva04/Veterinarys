using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinarys.Shared.Entities
{
    public class Owner
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Documento es requerido")]
        public string IdentificationCard { get; set; } = null;

        [Required(ErrorMessage = "El primer nombre es requerido")]
        public string FirstName { get; set; } = null;

        [Required(ErrorMessage = "El apellido es requerido")]
        public string LastName { get; set; } = null;

        [Required(ErrorMessage = "El telefono fijo es requerido")]
        public string FixedPhone { get; set; } = null;

        [Required(ErrorMessage = "El telefono celular es requerido")]
        public string CellPhone { get; set; } = null;

        [Required(ErrorMessage = "La direccion es requerida")]
        public string Address { get; set; } = null;

        public string FullName => $"{FirstName}{LastName}";

    }
}
