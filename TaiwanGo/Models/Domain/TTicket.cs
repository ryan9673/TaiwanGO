using System;
using System.Collections.Generic;

namespace TaiwanGo.Models.Domain;

public partial class TTicket
{
    public int FId { get; set; }

    public int FAttractionId { get; set; }

    public string FTicketName { get; set; } = null!;

    public decimal FPrice { get; set; }

    public string? FDescription { get; set; }

    public DateOnly? FValidDateStart { get; set; }

    public DateOnly? FValidDateEnd { get; set; }

    public bool? FIsActive { get; set; }

    public virtual TAttraction FAttraction { get; set; } = null!;

    public virtual ICollection<TBooking> TBookings { get; set; } = new List<TBooking>();
}
