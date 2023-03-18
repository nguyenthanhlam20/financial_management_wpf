using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinancialLibrary.Models
{
    public partial class FinancialManagementContext : DbContext
    {
        public FinancialManagementContext()
        {
        }

        public FinancialManagementContext(DbContextOptions<FinancialManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthenticationType> AuthenticationTypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-ALU23ESG;database=FinancialManagement;uid=sa;pwd=55555");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthenticationType>(entity =>
            {
                entity.ToTable("Authentication_Type");

                entity.Property(e => e.AuthenticationTypeId).HasColumnName("authentication_type_id");

                entity.Property(e => e.AuthenticationTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("authentication_type_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AuthenticationTypeId).HasColumnName("authentication_type_id");

                entity.Property(e => e.AvatarUrl)
                    .IsUnicode(false)
                    .HasColumnName("avatar_url");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.AuthenticationType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AuthenticationTypeId)
                    .HasConstraintName("FK__User__authentica__3B75D760");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK__User__role__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
