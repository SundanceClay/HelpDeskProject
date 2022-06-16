using System;
using System.Collections.Generic;

namespace HelpDeskProject.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Users = new HashSet<User>();
        }

        public int TicketId { get; set; }
        public string? Title { get; set; }
        public string? Contents { get; set; }
        public bool? Closed { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
