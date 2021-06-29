using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IP
{
    public partial class BDDPContext : DbContext
    {
        public BDDPContext()
        {
        }

        public BDDPContext(DbContextOptions<BDDPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Effectxvacunnaion> Effectxvacunnaions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employeexappo> Employeexappos { get; set; }
        public virtual DbSet<Employeexcabin> Employeexcabins { get; set; }
        public virtual DbSet<SideEffect> SideEffects { get; set; }
        public virtual DbSet<TypeEmployee> TypeEmployees { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<WorkSector> WorkSectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=proyectovf;user=root;password=Supermario6");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointment");

                entity.HasIndex(e => e.DuiCitizen, "FK_apoxcity");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DuiCitizen).HasColumnName("dui_citizen");

                entity.Property(e => e.IdSideEffect)
                    .HasMaxLength(50)
                    .HasColumnName("id_side_effect");

                entity.Property(e => e.TypeDose).HasColumnName("type_dose");

                entity.HasOne(d => d.DuiCitizenNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DuiCitizen)
                    .HasConstraintName("FK_apoxcity");
            });

            modelBuilder.Entity<Cabin>(entity =>
            {
                entity.HasKey(e => e.IdCabin)
                    .HasName("PRIMARY");

                entity.ToTable("cabin");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.Phone).HasColumnName("phone");
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.HasKey(e => e.Dui)
                    .HasName("PRIMARY");

                entity.ToTable("citizen");

                entity.HasIndex(e => e.IdWorkSector, "fk_Cityxsector");

                entity.Property(e => e.Dui).HasColumnName("dui");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.Property(e => e.IdWorkSector).HasColumnName("id_work_sector");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.IdWorkSectorNavigation)
                    .WithMany(p => p.Citizens)
                    .HasForeignKey(d => d.IdWorkSector)
                    .HasConstraintName("fk_Cityxsector");
            });

            modelBuilder.Entity<Effectxvacunnaion>(entity =>
            {
                entity.HasKey(e => new { e.IdSide, e.IdVaci })
                    .HasName("PRIMARY");

                entity.ToTable("effectxvacunnaion");

                entity.HasIndex(e => e.IdVaci, "FK_efecxvacu");

                entity.Property(e => e.IdSide).HasColumnName("id_side");

                entity.Property(e => e.IdVaci).HasColumnName("id_vaci");

                entity.HasOne(d => d.IdSideNavigation)
                    .WithMany(p => p.Effectxvacunnaions)
                    .HasForeignKey(d => d.IdSide)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sidexvacci");

                entity.HasOne(d => d.IdVaciNavigation)
                    .WithMany(p => p.Effectxvacunnaions)
                    .HasForeignKey(d => d.IdVaci)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_efecxvacu");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.IdTypeEmployee, "FK_Emxtype");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdTypeEmployee).HasColumnName("id_type_employee");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.HasOne(d => d.IdTypeEmployeeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdTypeEmployee)
                    .HasConstraintName("FK_Emxtype");
            });

            modelBuilder.Entity<Employeexappo>(entity =>
            {
                entity.HasKey(e => new { e.IdEmployee, e.IdAppointment })
                    .HasName("PRIMARY");

                entity.ToTable("employeexappo");

                entity.HasIndex(e => e.IdAppointment, "FK_appoxid");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.Employeexappos)
                    .HasForeignKey(d => d.IdAppointment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_appoxid");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Employeexappos)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKemploxid");
            });

            modelBuilder.Entity<Employeexcabin>(entity =>
            {
                entity.HasKey(e => new { e.IdEmployee, e.IdCabin })
                    .HasName("PRIMARY");

                entity.ToTable("employeexcabin");

                entity.HasIndex(e => e.IdCabin, "FK_empoxcabin");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

                entity.Property(e => e.IdCabin).HasColumnName("id_cabin");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.HasOne(d => d.IdCabinNavigation)
                    .WithMany(p => p.Employeexcabins)
                    .HasForeignKey(d => d.IdCabin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empoxcabin");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Employeexcabins)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_empox");
            });

            modelBuilder.Entity<SideEffect>(entity =>
            {
                entity.ToTable("side_effect");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disease)
                    .HasMaxLength(50)
                    .HasColumnName("disease");
            });

            modelBuilder.Entity<TypeEmployee>(entity =>
            {
                entity.ToTable("type_employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Vaccination>(entity =>
            {
                entity.ToTable("vaccination");

                entity.HasIndex(e => e.IdAppointment, "FK_Vacixapo");

                entity.HasIndex(e => e.DuiCitizen, "FK_Vacixdui");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DuiCitizen).HasColumnName("dui_citizen");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdAppointment).HasColumnName("id_appointment");

                entity.HasOne(d => d.IdAppointmentNavigation)
                    .WithMany(p => p.Vaccinations)
                    .HasForeignKey(d => d.IdAppointment)
                    .HasConstraintName("FK_Vacixapo");
            });

            modelBuilder.Entity<WorkSector>(entity =>
            {
                entity.ToTable("work_sector");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .HasColumnName("sector");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
