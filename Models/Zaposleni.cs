//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationFPIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zaposleni
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zaposleni()
        {
            this.Kvar = new HashSet<Kvar>();
        }
    
        public int ZaposleniID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kvar> Kvar { get; set; }
        public virtual ZahtevZaDodatneUsluge ZahtevZaDodatneUsluge { get; set; }

        public override string ToString() => $"{Ime} {Prezime}";
    }
}
