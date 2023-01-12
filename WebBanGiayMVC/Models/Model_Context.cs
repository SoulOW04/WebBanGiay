using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebBanGiayMVC.Models
{
    public partial class Model_Context : DbContext
    {
        public Model_Context()
            : base("name=Model_Context1")
        {
        }

        public virtual DbSet<CauHinh> CauHinhs { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<SanPhamTrongDanhMuc> SanPhamTrongDanhMucs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThongSoKiThuat> ThongSoKiThuats { get; set; }
        public virtual DbSet<ThongSoSanPham> ThongSoSanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
