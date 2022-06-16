using System;
using System.Collections.Generic;

namespace HelpDeskProject.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? HelperName { get; set; }
        public int? TicketsAssigned { get; set; }

        public virtual Ticket? TicketsAssignedNavigation { get; set; }
    }
}
