namespace TaiwanGo.Models.Domain;

public partial class TUser
{
    public int FId { get; set; }

    public string FName { get; set; } = null!;

    public string FEmail { get; set; } = null!;

    public string FPassword { get; set; } = null!;

    public string? FPhone { get; set; }

    public DateOnly? FBirthDate { get; set; }

    public string? FGender { get; set; }

    public DateTime? FCreatedAt { get; set; }

    public bool? FIsActive { get; set; }

    public virtual ICollection<TBooking> TBookings { get; set; } = new List<TBooking>();
}
