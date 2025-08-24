using System.ComponentModel;
using TaiwanGo.Models.Domain;

namespace TaiwanGo.Models.Wrap
{
    public class CTicketWrap
    {
        private TTicket _ticket = null;
        public TTicket ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }
        public CTicketWrap()
        {
            _ticket = new TTicket();
        }
        public CTicketWrap(TTicket a)
        {
            _ticket = a;
        }
        public int FId
        {
            get { return _ticket.FId; }
            set { _ticket.FId = value; }
        }
        public int FAttractionId {
            get { return _ticket.FAttractionId; }
            set { _ticket.FAttractionId = value; }
        }
        [DisplayName("票券名稱")]
        public string FTicketName {
            get { return _ticket.FTicketName; }
            set { _ticket.FTicketName = value; }
        }
        [DisplayName("票券價格")]
        public decimal FPrice {
            get { return _ticket.FPrice; }
            set { _ticket.FPrice = value; }
        }
        [DisplayName("票券描述")]
        public string? FDescription {
            get { return _ticket.FDescription; }
            set { _ticket.FDescription = value; }
        }
        [DisplayName("票券生效日期")]
        public DateOnly? FValidDateStart {
            get { return _ticket.FValidDateStart; }
            set { _ticket.FValidDateStart = value; }
        }
        [DisplayName("票券截止日期")]
        public DateOnly? FValidDateEnd {
            get { return _ticket.FValidDateEnd; }
            set { _ticket.FValidDateEnd = value; }
        }

        public bool? FIsActive {
            get { return _ticket.FIsActive; }
            set { _ticket.FIsActive = value; }
        }
    }
}
