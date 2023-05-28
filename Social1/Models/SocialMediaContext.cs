using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Social1.Models;

public partial class SocialMediaContext : DbContext
{
    public SocialMediaContext()
    {
    }

    public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Commant> Commants { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Adduser");

            entity.ToTable("AppUser");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Commant>(entity =>
        {
            entity.ToTable("Commant");

            entity.Property(e => e.Body).HasMaxLength(50);
            entity.Property(e => e.Data).HasColumnType("date");

            entity.HasOne(d => d.Appuser).WithMany(p => p.Commants)
                .HasForeignKey(d => d.Appuserid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Commant_AppUser1");

            entity.HasOne(d => d.Post).WithMany(p => p.Commants)
                .HasForeignKey(d => d.Postid)
                .HasConstraintName("FK_Commant_Post");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Body).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Appuser).WithMany(p => p.Posts)
                .HasForeignKey(d => d.Appuserid)
                .HasConstraintName("FK_Post_AppUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
