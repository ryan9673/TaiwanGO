using System;
using System.Collections.Generic;

namespace TaiwanGo.Models.Domain;

public partial class TAttractionCategory
{
    public int FId { get; set; }

    public string FCategoryName { get; set; } = null!;

    public virtual ICollection<TAttraction> TAttractions { get; set; } = new List<TAttraction>();
}
