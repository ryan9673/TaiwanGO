using TaiwanGo.Models.Domain;

namespace TaiwanGo.Models.Wrap
{
    public class CBookingWrap
    {
        private TBooking _booking = null;
        public TBooking booking
        {
            get { return _booking; }
            set { _booking = value; }
        }
        public CBookingWrap()
        {
            _booking = new TBooking();
        }
        public CBookingWrap(TBooking b)
        {
            _booking = b;
        }
        public int FId
        {
            get { return _booking.FId; }
            set { _booking.FId = value; }
        }
        public int FUserId
        {
            get { return _booking.FUserId; }
            set { _booking.FUserId = value; }
        }
        public int FTicketId
        {
            get { return _booking.FTicketId; }
            set { _booking.FTicketId = value; }
        }
        public DateOnly FBookingDate
        {
            get { return _booking.FBookingDate; }
            set { _booking.FBookingDate = value; }
        }
        public int FQuantity
        {
            get { return _booking.FQuantity; }
            set { _booking.FQuantity = value; }
        }
        public decimal FUnitPrice
        {
            get { return _booking.FUnitPrice; }
            set { _booking.FUnitPrice = value; }
        }
        public decimal? FTotalAmount
        {
            get { return _booking.FTotalAmount; }
            set { _booking.FTotalAmount = value; }
        }
        public DateTime? FCreatedAt
        {
            get { return _booking.FCreatedAt; }
            set { _booking.FCreatedAt = value; }
        }

        // ===== 額外提供關聯的便利屬性 =====
        public string? UserName => _booking.FUser?.FName;
        public string? TicketName => _booking.FTicket?.FTicketName;
        public string? AttractionName => _booking.FTicket?.FAttraction?.AttractionName;
        public string? CategoryName => _booking.FTicket?.FAttraction?.FCategory?.FCategoryName;
    }
}
