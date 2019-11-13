namespace MvcTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKisi")]
    public partial class tblKisi
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(50)]
        public string CalistigiYer { get; set; }

        public double? Agno { get; set; }

        [StringLength(50)]
        public string MezunYil { get; set; }

        [StringLength(50)]
        public string Eposta { get; set; }

        [StringLength(50)]
        public string Sifre { get; set; }

        public int? YetkiId { get; set; }

        [StringLength(250)]
        public string Foto { get; set; }

        public int? BolumId { get; set; }

        [StringLength(50)]
        public string Staj1 { get; set; }

        [StringLength(50)]
        public string Staj2 { get; set; }

        [StringLength(50)]
        public string IsYeriEgitimi { get; set; }

        public virtual tblBolum tblBolum { get; set; }

        public virtual tblYetki tblYetki { get; set; }
    }
}
