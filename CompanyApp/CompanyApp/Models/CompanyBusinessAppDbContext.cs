using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyApp.Models
{
    public partial class CompanyBusinessAppDbContext : DbContext
    {
        public CompanyBusinessAppDbContext()
        {
        }

        public CompanyBusinessAppDbContext(DbContextOptions<CompanyBusinessAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessUnits> BusinessUnits { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<ProjectTeams> ProjectTeams { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Vacations> Vacations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SHIVAM-DUBEY\\SQLEXPRESS;Database=CompanyBusinessAppDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessUnits>(entity =>
            {
                entity.HasKey(e => e.BusinessUnitId);

                entity.Property(e => e.BusinessUnitName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_BusinessUnits");
            });

            modelBuilder.Entity<ProjectTeams>(entity =>
            {
                entity.HasKey(e => e.ProjectTeamId);

                entity.Property(e => e.EmployeeDesignation)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ProjectTeams)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectTeams_Employees");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectTeams)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectTeams_Projects");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.BusinessUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_BusinessUnits");
            });

            modelBuilder.Entity<Vacations>(entity =>
            {
                entity.HasKey(e => e.VacationId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Vacations)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacations_Employees");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
