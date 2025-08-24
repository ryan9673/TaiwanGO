using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaiwanGo.Models.Domain;

public partial class TaiwanGoContext : DbContext
{
    public TaiwanGoContext()
    {
    }

    public TaiwanGoContext(DbContextOptions<TaiwanGoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAttraction> TAttractions { get; set; }

    public virtual DbSet<TAttractionCategory> TAttractionCategories { get; set; }

    public virtual DbSet<TBooking> TBookings { get; set; }

    public virtual DbSet<TStaff> TStaffs { get; set; }

    public virtual DbSet<TTicket> TTickets { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TaiwanGo;User ID=sa;Password=P@ssw0rd;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAttraction>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tAttract__D9F8227C2D0FB632");

            entity.ToTable("tAttractions");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.AttractionName).HasMaxLength(100);
            entity.Property(e => e.FCategoryId).HasColumnName("fCategoryId");
            entity.Property(e => e.FDescription).HasColumnName("fDescription");
            entity.Property(e => e.FImage)
                .HasMaxLength(255)
                .HasColumnName("fImage");
            entity.Property(e => e.FLocation)
                .HasMaxLength(255)
                .HasColumnName("fLocation");

            entity.HasOne(d => d.FCategory).WithMany(p => p.TAttractions)
                .HasForeignKey(d => d.FCategoryId)
                .HasConstraintName("FK__tAttracti__fCate__619B8048");
        });

        modelBuilder.Entity<TAttractionCategory>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tAttract__D9F8227C1386431F");

            entity.ToTable("tAttractionCategories");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FCategoryName)
                .HasMaxLength(100)
                .HasColumnName("fCategoryName");
        });

        modelBuilder.Entity<TBooking>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tBooking__D9F8227CB1D61548");

            entity.ToTable("tBookings");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FBookingDate).HasColumnName("fBookingDate");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FQuantity).HasColumnName("fQuantity");
            entity.Property(e => e.FTicketId).HasColumnName("fTicketId");
            entity.Property(e => e.FTotalAmount)
                .HasComputedColumnSql("([fQuantity]*[fUnitPrice])", true)
                .HasColumnType("decimal(21, 2)")
                .HasColumnName("fTotalAmount");
            entity.Property(e => e.FUnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fUnitPrice");
            entity.Property(e => e.FUserId).HasColumnName("fUserId");

            entity.HasOne(d => d.FTicket).WithMany(p => p.TBookings)
                .HasForeignKey(d => d.FTicketId)
                .HasConstraintName("FK__tBookings__fTick__6B24EA82");

            entity.HasOne(d => d.FUser).WithMany(p => p.TBookings)
                .HasForeignKey(d => d.FUserId)
                .HasConstraintName("FK__tBookings__fUser__6A30C649");
        });

        modelBuilder.Entity<TStaff>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tStaff__D9F8227CD32340E1");

            entity.ToTable("tStaff");

            entity.HasIndex(e => e.FEmail, "UQ__tStaff__E609A9E5E5563FEE").IsUnique();

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FEmail)
                .HasMaxLength(100)
                .HasColumnName("fEmail");
            entity.Property(e => e.FIsActive)
                .HasDefaultValue(true)
                .HasColumnName("fIsActive");
            entity.Property(e => e.FName)
                .HasMaxLength(100)
                .HasColumnName("fName");
            entity.Property(e => e.FPassword)
                .HasMaxLength(255)
                .HasColumnName("fPassword");
            entity.Property(e => e.FPhone)
                .HasMaxLength(20)
                .HasColumnName("fPhone");
            entity.Property(e => e.FRole)
                .HasMaxLength(50)
                .HasColumnName("fRole");
        });

        modelBuilder.Entity<TTicket>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tTickets__D9F8227C0357F6D0");

            entity.ToTable("tTickets");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FAttractionId).HasColumnName("fAttractionId");
            entity.Property(e => e.FDescription)
                .HasMaxLength(255)
                .HasColumnName("fDescription");
            entity.Property(e => e.FIsActive)
                .HasDefaultValue(true)
                .HasColumnName("fIsActive");
            entity.Property(e => e.FPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("fPrice");
            entity.Property(e => e.FTicketName)
                .HasMaxLength(100)
                .HasColumnName("fTicketName");
            entity.Property(e => e.FValidDateEnd).HasColumnName("fValidDateEnd");
            entity.Property(e => e.FValidDateStart).HasColumnName("fValidDateStart");

            entity.HasOne(d => d.FAttraction).WithMany(p => p.TTickets)
                .HasForeignKey(d => d.FAttractionId)
                .HasConstraintName("FK__tTickets__fAttra__656C112C");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tUser__D9F8227CBC8ABA46");

            entity.ToTable("tUser");

            entity.HasIndex(e => e.FEmail, "UQ__tUser__E609A9E5E73A9C0D").IsUnique();

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FBirthDate).HasColumnName("fBirthDate");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FEmail)
                .HasMaxLength(255)
                .HasColumnName("fEmail");
            entity.Property(e => e.FGender)
                .HasMaxLength(10)
                .HasColumnName("fGender");
            entity.Property(e => e.FIsActive)
                .HasDefaultValue(true)
                .HasColumnName("fIsActive");
            entity.Property(e => e.FName)
                .HasMaxLength(100)
                .HasColumnName("fName");
            entity.Property(e => e.FPassword)
                .HasMaxLength(255)
                .HasColumnName("fPassword");
            entity.Property(e => e.FPhone)
                .HasMaxLength(15)
                .HasColumnName("fPhone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
