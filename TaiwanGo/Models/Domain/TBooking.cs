using System;
using System.Collections.Generic;

namespace TaiwanGo.Models.Domain;

public partial class TBooking
{
    public int FId { get; set; }

    public int FUserId { get; set; }

    public int FTicketId { get; set; }

    public DateOnly FBookingDate { get; set; }

    public int FQuantity { get; set; }

    public decimal FUnitPrice { get; set; }

    public decimal? FTotalAmount { get; set; }

    public DateTime? FCreatedAt { get; set; }

    public virtual TTicket FTicket { get; set; } = null!;

    public virtual TUser FUser { get; set; } = null!;
}
