using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Laundry.Models
{
    public partial class LaundryContext : DbContext
    {
        public LaundryContext()
        {
        }

        public LaundryContext(DbContextOptions<LaundryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bos> Bos { get; set; }
        public virtual DbSet<DetailPelayanan> DetailPelayanan { get; set; }
        public virtual DbSet<Karyawan> Karyawan { get; set; }
        public virtual DbSet<Pesanan> Pesanan { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bos>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetailPelayanan>(entity =>
            {
                entity.HasKey(e => e.IdKaryawan);

                entity.ToTable("Detail_Pelayanan");

                entity.Property(e => e.IdKaryawan)
                    .HasColumnName("ID_Karyawan")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPesanan).HasColumnName("ID_Pesanan");
            });

            modelBuilder.Entity<Karyawan>(entity =>
            {
                entity.HasKey(e => e.IdKaryawan);

                entity.Property(e => e.IdKaryawan).HasColumnName("ID_Karyawan");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JnsKelamin)
                    .HasColumnName("Jns_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NamaKaryawan)
                    .HasColumnName("Nama_Karyawan")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pesanan>(entity =>
            {
                entity.HasKey(e => e.IdPesanan);

                entity.Property(e => e.IdPesanan).HasColumnName("ID_Pesanan");

                entity.Property(e => e.BeratTotal).HasColumnName("Berat_Total");

                entity.Property(e => e.HrgSatuan).HasColumnName("Hrg_Satuan");

                entity.Property(e => e.HrgTotal).HasColumnName("Hrg_Total");

                entity.Property(e => e.NamaCustomer)
                    .HasColumnName("Nama_Customer")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TglPesanan)
                    .HasColumnName("Tgl_Pesanan")
                    .HasColumnType("datetime");

                entity.Property(e => e.Tipe)
                    .HasMaxLength(7)
                    .IsUnicode(false);
            });
        }
    }
}
