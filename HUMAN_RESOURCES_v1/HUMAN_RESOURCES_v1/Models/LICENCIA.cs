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

    public partial class LICENCIA
    {
        public int id_licencia { get; set; }
        [Required]
        [Display(Name = "Codigo del Empleado (ID)")]
        public int id_empleado { get; set; }
        [Required]
        [Display(Name = "Fecha de Inicio de la Licencia")]
        public Nullable<System.DateTime> fecha_inicio_licencia { get; set; }
        [Required]
        [Display(Name = "Fecha de Fin de la Licencia")]
        public System.DateTime fecha_fin_licencia { get; set; }
        [Required]
        [Display(Name = "Motivo de la Licencia")]
        public string motivo_licencia { get; set; }
        [Required]
        [Display(Name = "Comentario de la Licencia")]
        public string comentario_varchar { get; set; }
    
        public virtual EMPLEADO EMPLEADO { get; set; }
    }
}
