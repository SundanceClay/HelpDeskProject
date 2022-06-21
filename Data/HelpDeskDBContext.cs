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

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<BookMark> BookMark { get; set; }

    }
}
