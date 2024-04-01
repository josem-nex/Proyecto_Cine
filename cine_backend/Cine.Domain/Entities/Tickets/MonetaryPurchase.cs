namespace Cine.Domain.Entities.Tickets;
public class MonetaryPurchase
{
    public User? User { get; private set; }
    public Guid UserId { get; private set; }
    public Ticket? Tickets { get; private set; }
    public int TicketsId { get; private set; }
    public int TotalPrice { get; private set; }
    public string? CreditCard { get; private set; }
    public MonetaryPurchase(Guid userId, int ticketsId, int totalPrice, string creditCard)
    {
        // User = user;
        UserId = userId;
        // Tickets = tickets;
        TicketsId = ticketsId;
        TotalPrice = totalPrice;
        CreditCard = creditCard;
    }
    public void Update(Guid userId, int ticketsId, int totalPrice, string creditCard)
    {
        // User = user;
        UserId = userId;
        // Tickets = tickets;
        TicketsId = ticketsId;
        TotalPrice = totalPrice;
        CreditCard = creditCard;
    }
}