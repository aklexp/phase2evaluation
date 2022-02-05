using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace travelplans.Models
{
    public partial class phase2Context : DbContext
    {
        public phase2Context()
        {
        }

        public phase2Context(DbContextOptions<phase2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Destination> Destination { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Planperiod> Planperiods { get; set; }
        public virtual DbSet<Planprice> Planprices { get; set; }
        public virtual DbSet<Transpordmode> Transpordmodes { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= AKHILM\\SQLEXPRESS; Initial Catalog= phase2; Integrated security=True");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Destination>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("PK__Destinat__C0365630641413B3");

                entity.ToTable("Destination");

                entity.Property(e => e.Did).HasColumnName("DID");

                entity.Property(e => e.Dname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.HasKey(e => new { e.Pid, e.Did })
                    .HasName("PK__Place__D9743043EF1337CE");

                entity.ToTable("Place");

                entity.Property(e => e.Pid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PID");

                entity.Property(e => e.Did).HasColumnName("DID");

                entity.Property(e => e.Pname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.DidNavigation)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.Did)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Place__DID__38996AB5");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Plid)
                    .HasName("PK__Plans__5ED8B98BCC451634");

                entity.Property(e => e.Plid).HasColumnName("PLID");

                entity.Property(e => e.Did).HasColumnName("DID");

                entity.Property(e => e.Plname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PLname")
                    .IsFixedLength(true);

                entity.HasOne(d => d.DidNavigation)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.Did)
                    .HasConstraintName("FK__Plans__DID__3B75D760");
            });

            modelBuilder.Entity<Planperiod>(entity =>
            {
                entity.HasKey(e => new { e.PeriodId, e.Plid })
                    .HasName("PK__Planperi__40CC30AE997130BF");

                entity.ToTable("Planperiod");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.Plid).HasColumnName("PLID");

                entity.Property(e => e.Noofdays).HasColumnName("noofdays");

                entity.HasOne(d => d.Pl)
                    .WithMany(p => p.Planperiods)
                    .HasForeignKey(d => d.Plid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planperiod__PLID__3E52440B");
            });

            modelBuilder.Entity<Planprice>(entity =>
            {
                entity.HasKey(e => new { e.Ppid, e.PeriodId, e.Tid, e.Plid })
                    .HasName("PK__Planpric__91EB29227E354016");

                entity.ToTable("Planprice");

                entity.Property(e => e.Ppid).HasColumnName("PPID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Plid).HasColumnName("PLID");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.HasOne(d => d.Pl)
                    .WithMany(p => p.Planprices)
                    .HasForeignKey(d => d.Plid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planprice__PLID__440B1D61");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Planprices)
                    .HasForeignKey(d => new { d.PeriodId, d.Plid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planprice__44FF419A");

                entity.HasOne(d => d.Transpordmode)
                    .WithMany(p => p.Planprices)
                    .HasForeignKey(d => new { d.Tid, d.Plid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planprice__45F365D3");
            });

            modelBuilder.Entity<Transpordmode>(entity =>
            {
                entity.HasKey(e => new { e.Tid, e.Plid })
                    .HasName("PK__Transpor__61BB5CB1F313614C");

                entity.ToTable("Transpordmode");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.Plid).HasColumnName("PLID");

                entity.Property(e => e.Tname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Pl)
                    .WithMany(p => p.Transpordmodes)
                    .HasForeignKey(d => d.Plid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transpordm__PLID__412EB0B6");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
