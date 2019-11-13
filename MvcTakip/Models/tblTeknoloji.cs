namespace MvcTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTeknoloji")]
    public partial class tblTeknoloji
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTeknoloji()
        {
            tblKisis = new HashSet<tblKisi>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string KullandigiTeknoloji { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblKisi> tblKisis { get; set; }
    }
}
