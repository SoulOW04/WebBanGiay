namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongSoKiThuat")]
    public partial class ThongSoKiThuat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "GiaTri is required")]
        public string GiaTri { get; set; }
    }
}
