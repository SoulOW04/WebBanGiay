

namespace WebBanGiayMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public class Admin
    {
       public int Admmin_id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string AdmUserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string AdmPassword { get; set; }
    }
}