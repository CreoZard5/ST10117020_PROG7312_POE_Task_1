using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PROG7312_POE_ST10117020.ModelServer
{
    public partial class PROG_ST10117020Context : DbContext
    {
        public PROG_ST10117020Context()
        {
        }

        public PROG_ST10117020Context(DbContextOptions<PROG_ST10117020Context> options)
            : base(options)
        {
        }

        public virtual DbSet<LeaderboardItem> LeaderboardItems { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaderboardItem>(entity =>
            {
                entity.HasKey(e => e.LeaderboardId)
                    .HasName("PK__Leaderbo__B358A1E69CFC8637");

                entity.Property(e => e.LeaderboardId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("LeaderboardID");

                entity.Property(e => e.LeaderboardGameType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LeaderboardItems)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leaderboa__UserI__276EDEB3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserUsername)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
