//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoHogarDulceCorazonJoelGramajo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estados_de_tratamientos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estados_de_tratamientos()
        {
            this.Asignar_padecimiento_a_ficha_médica = new HashSet<Asignar_padecimiento_a_ficha_médica>();
        }
    
        public int Estado_de_tratamiento { get; set; }
        public string Nombre_estado_tratamiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asignar_padecimiento_a_ficha_médica> Asignar_padecimiento_a_ficha_médica { get; set; }
    }
}
