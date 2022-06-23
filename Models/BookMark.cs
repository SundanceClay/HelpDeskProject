namespace HelpDeskProject.Models
{
    public class BookMark
    {
        public int BookMarkId { get; set; }
        public int TicketId { get; set; }

        public int UserId { get; set; }
        /* public Ticket Ticket { get; set; }
        public User User { get; set; } */
    }
}
