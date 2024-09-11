using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test_WebAtrio.Models;

namespace Test_WebAtrio.DbContexts;

public partial class TestWebAtrioContext : DbContext
{
    public TestWebAtrioContext()
    {
    }

    public TestWebAtrioContext(DbContextOptions<TestWebAtrioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emploi> Emplois { get; set; }

    public virtual DbSet<Personne> Personnes { get; set; }

    public virtual DbSet<PersonneEmployée> PersonneEmployées { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emploi>(entity =>
        {
            entity.HasKey(e => e.EmploiId).HasName("PK__Emplois__A45F449C6800DB93");

            entity.Property(e => e.EmploiId).HasColumnName("emploiID");
            entity.Property(e => e.Entreprise)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("entreprise");
            entity.Property(e => e.Poste)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("poste");
        });

        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.PersonneId).HasName("PK__Personne__ABAA888833F56977");

            entity.Property(e => e.PersonneId).HasColumnName("personneID");
            entity.Property(e => e.DateDeNaissance)
                .HasColumnType("datetime")
                .HasColumnName("dateDeNaissance");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prenom");
        });

        modelBuilder.Entity<PersonneEmployée>(entity =>
        {
            entity.HasKey(e => e.PersonneEmployee).HasName("PK__Personne__6A01F69001BF3AF3");

            entity.ToTable("Personne_Employée");

            entity.Property(e => e.PersonneEmployee).HasColumnName("personneEmployee");
            entity.Property(e => e.DateDebut)
                .HasColumnType("datetime")
                .HasColumnName("dateDebut");
            entity.Property(e => e.DateFin)
                .HasColumnType("datetime")
                .HasColumnName("dateFin");
            entity.Property(e => e.EmploiId).HasColumnName("emploiID");
            entity.Property(e => e.PersonneId).HasColumnName("personneID");

            entity.HasOne(d => d.Emploi).WithMany(p => p.PersonneEmployées)
                .HasForeignKey(d => d.EmploiId)
                .HasConstraintName("FK_Emploi");

            entity.HasOne(d => d.Personne).WithMany(p => p.PersonneEmployées)
                .HasForeignKey(d => d.PersonneId)
                .HasConstraintName("FK_Personne");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
