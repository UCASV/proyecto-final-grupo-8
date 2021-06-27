using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IP
{
    public partial class Rcontext : DbContext
    {
        public Rcontext()
        {
        }

        public Rcontext(DbContextOptions<Rcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Cabin> Cabins { get; set; }
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
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
                optionsBuilder.UseMySQL("server=localhost;database=Proyecto3;user=root;password=Lacasadepapel123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdApo)
                    .HasName("PRIMARY");

                entity.ToTable("appointment");

                entity.HasIndex(e => e.Disease, "FK_apo_dise");

                entity.HasIndex(e => e.DuiCitizen, "FK_apoxcity");

                entity.Property(e => e.IdApo).HasColumnName("id_apo");

                entity.Property(e => e.Disease).HasColumnName("disease");

                entity.Property(e => e.DuiCitizen).HasColumnName("dui_citizen");

                entity.Property(e => e.TypeDose).HasColumnName("type_dose");

                entity.HasOne(d => d.DiseaseNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.Disease)
                    .HasConstraintName("FK_apo_dise");

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

            modelBuilder.Entity<Disease>(entity =>
            {
                entity.ToTable("disease");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disease1)
                    .HasMaxLength(50)
                    .HasColumnName("disease");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.HasIndex(e => e.IdTypeEmployee, "FK_Emxtype");

                entity.Property(e => e.IdEmployee).HasColumnName("id_employee");

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
                entity.HasKey(e => e.IdSide)
                    .HasName("PRIMARY");

                entity.ToTable("side_effect");

                entity.HasIndex(e => e.DuiCitizen, "FK_sidexcity");

                entity.Property(e => e.IdSide).HasColumnName("id_side");

                entity.Property(e => e.DuiCitizen).HasColumnName("dui_citizen");

                entity.Property(e => e.SequelName)
                    .HasMaxLength(50)
                    .HasColumnName("sequel_name");
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
                entity.HasKey(e => e.IdVaci)
                    .HasName("PRIMARY");

                entity.ToTable("vaccination");

                entity.HasIndex(e => e.IdAppointment, "FK_Vacixapo");

                entity.HasIndex(e => e.DuiCitizen, "FK_Vacixdui");

                entity.Property(e => e.IdVaci).HasColumnName("id_vaci");

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
                entity.HasKey(e => e.IdWorkSector)
                    .HasName("PRIMARY");

                entity.ToTable("work_sector");

                entity.Property(e => e.IdWorkSector).HasColumnName("id_work_sector");

                entity.Property(e => e.Sector)
                    .HasMaxLength(50)
                    .HasColumnName("sector");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
