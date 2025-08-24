using System.ComponentModel;

namespace TaiwanGo.Models.Domain;

public partial class TStaff
{
    public int FId { get; set; }
    [DisplayName("姓名")]
    public string FName { get; set; } = null!;

    public string FEmail { get; set; } = null!;

    public string FPassword { get; set; } = null!;

    public string FRole { get; set; } = null!;

    public string? FPhone { get; set; }

    public DateTime? FCreatedAt { get; set; }

    public bool? FIsActive { get; set; }
}
