//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vuelo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vuelo()
        {
            this.Intercontinental = new HashSet<Intercontinental>();
            this.Nacional = new HashSet<Nacional>();
            this.Regional = new HashSet<Regional>();
        }
    
        public string numeroVuelo { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public System.DateTime dtLlegada { get; set; }
        public System.DateTime dtSalida { get; set; }
        public double HorasTotales { get; set; }
        public double precio { get; set; }
        public Nullable<int> numeroAeronaveAsignada { get; set; }
        public int desde { get; set; }
        public int hasta { get; set; }
        public string tipo { get; set; }
    
        public virtual Aeronave Aeronave { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intercontinental> Intercontinental { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nacional> Nacional { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regional> Regional { get; set; }
    }
}
