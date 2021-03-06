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

    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.LICENCIAS = new HashSet<LICENCIA>();
            this.PERMISOS = new HashSet<PERMISO>();
            this.VACACIONES = new HashSet<VACACIONE>();
        }

        public int id_empleado { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "Departamento")]
        public int id_departamento { get; set; }
        [Required]
        [Display(Name = "Cargo/Funcion")]
        public int id_cargo { get; set; }
        [Required]
        [Display(Name = "Fecha Ingreso")]
        public System.DateTime fecha_ingreso { get; set; }
        [Required]
        [Display(Name = "Salario")]
        public decimal salario { get; set; }
        [Required]
        [Display(Name = "Estatus Empleado")]
        public string estatus { get; set; }
        [Display(Name = "Salida Empleado")]
        public Nullable<int> id_salida_empleado { get; set; }

        public virtual CARGO CARGO { get; set; }
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICENCIA> LICENCIAS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERMISO> PERMISOS { get; set; }
        public virtual SALIDA_EMPLEADOS SALIDA_EMPLEADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VACACIONE> VACACIONES { get; set; }
    }

}
