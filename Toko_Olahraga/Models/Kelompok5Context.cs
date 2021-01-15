using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Toko_Olahraga.Models
{
    public partial class Kelompok5Context : DbContext
    {
        public Kelompok5Context()
        {
        }

        public Kelompok5Context(DbContextOptions<Kelompok5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Barang> Barang { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<StaffGudang> StaffGudang { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin);

                entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");

                entity.Property(e => e.NamaAdmin)
                    .HasColumnName("Nama_Admin")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.Property(e => e.IdBarang).HasColumnName("Id_Barang");

                entity.Property(e => e.IdAdmin).HasColumnName("Id_Admin");

                entity.Property(e => e.IdStaff).HasColumnName("Id_Staff");

                entity.Property(e => e.NamaBarang)
                    .HasColumnName("Nama_Barang")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Barang)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK_Barang_Admin");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.Barang)
                    .HasForeignKey(d => d.IdStaff)
                    .HasConstraintName("FK_Barang_Staff_Gudang");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.Property(e => e.IdPembeli).HasColumnName("Id_Pembeli");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPembeli)
                    .HasColumnName("Nama_Pembeli")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoTlp).HasColumnName("No_Tlp");
            });

            modelBuilder.Entity<StaffGudang>(entity =>
            {
                entity.HasKey(e => e.IdStaff);

                entity.ToTable("Staff_Gudang");

                entity.Property(e => e.IdStaff).HasColumnName("Id_Staff");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaStaff)
                    .HasColumnName("Nama_Staff")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoTlp).HasColumnName("No_Tlp");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.Property(e => e.IdTransaksi).HasColumnName("Id_Transaksi");

                entity.Property(e => e.IdBarang).HasColumnName("Id_Barang");

                entity.Property(e => e.IdPembeli).HasColumnName("Id_Pembeli");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tanggal).HasColumnType("date");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Transaksi_Barang");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK_Transaksi_Pembeli");
            });
        }
    }
}
