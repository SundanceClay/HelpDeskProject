using System;
using System.Collections.Generic;

namespace HelpDeskProject.Models
{
    public class Ticket
    {

        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        
        public string Resolution { get; set; }
        public bool Closed { get; set; }
    }
}
