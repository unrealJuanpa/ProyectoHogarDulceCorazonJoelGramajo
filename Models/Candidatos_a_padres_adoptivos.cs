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
    
    public partial class Candidatos_a_padres_adoptivos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Candidatos_a_padres_adoptivos()
        {
            this.Asignar_padre_a_adopción = new HashSet<Asignar_padre_a_adopción>();
        }
    
        public int Padre_adoptivo { get; set; }
        public string Nombre_padre { get; set; }
        public long DPI { get; set; }
        public string Dirección { get; set; }
        public string Correo { get; set; }
        public int Teléfono { get; set; }
        public string Dirección_de_trabajo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asignar_padre_a_adopción> Asignar_padre_a_adopción { get; set; }
    }
}
