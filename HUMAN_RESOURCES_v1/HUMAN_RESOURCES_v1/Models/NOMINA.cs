//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HUMAN_RESOURCES_v1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NOMINA
    {
        public int id_codigo { get; set; }
        [Required]
        [Display(Name = "Fecha de La nomina")]
        public System.DateTime fecha_nomina { get; set; }
        [Required]
        [Display(Name = "Monto Total de la Nomina")]
        public decimal monto_total { get; set; }
    }
}