using System;
using System.Collections.Generic;

namespace TaiwanGo.Models.Domain;

public partial class TAttraction
{
    public int FId { get; set; }

    public int FCategoryId { get; set; }

    public string AttractionName { get; set; } = null!;

    public string? FDescription { get; set; }

    public string? FLocation { get; set; }

    public string? FImage { get; set; }

    public virtual TAttractionCategory FCategory { get; set; } = null!;

    public virtual ICollection<TTicket> TTickets { get; set; } = new List<TTicket>();
}
