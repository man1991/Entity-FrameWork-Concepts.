namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCountry")]
    public partial class tblCountry
    {
        [Key]
        [StringLength(50)]
        public string CountryName { get; set; }

        public int? Population { get; set; }
    }
}
