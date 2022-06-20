using System;
using Microsoft.EntityFrameworkCore;
using HelpDeskProject.Models;

namespace HelpDeskProject.Data
{
    public partial class HelpDeskDBContext : DbContext
    {
        public HelpDeskDBContext()
        {
        }

        public HelpDeskDBContext(DbContextOptions<HelpDeskDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("Ticket_Id");

                entity.Property(e => e.Contents)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("User_Id");

                entity.Property(e => e.HelperName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TicketsAssigned).HasColumnName("Tickets_Assigned");

                entity.HasOne(d => d.TicketsAssignedNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TicketsAssigned)
                    .HasConstraintName("FK__Users__Tickets_A__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
