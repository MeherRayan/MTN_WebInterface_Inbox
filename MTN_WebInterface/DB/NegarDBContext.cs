using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace MTN_WebInterface_Inbox.DB
{
    public partial class NegarDBContext : DbContext
    {
        public NegarDBContext()
        {
        }

        public NegarDBContext(DbContextOptions<NegarDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TInboxMtn> TInboxMtn { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Startup.CnnString);
                //optionsBuilder.UseSqlServer(Startup.Configuration["NegarDB"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<TInboxMtn>(entity =>
            {
                entity.ToTable("T_Inbox_MTN");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Correlator)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Linkid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Media)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Sender)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Shortcode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpId)
                    .HasColumnName("SpID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeSpan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

        }
    }
}
