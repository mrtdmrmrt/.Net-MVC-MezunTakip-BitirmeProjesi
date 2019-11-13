namespace MvcTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStaj")]
    public partial class tblStaj
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblStaj()
        {
            tblKisis = new HashSet<tblKisi>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string Staj1 { get; set; }

        [StringLength(50)]
        public string Staj2 { get; set; }

        [StringLength(50)]
        public string IsYeriEgitimi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblKisi> tblKisis { get; set; }
    }
}
