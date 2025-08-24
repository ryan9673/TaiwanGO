using System.ComponentModel;
using TaiwanGo.Models.Domain;

namespace TaiwanGo.Models.Wrap
{
    public class CStaffWrap
    {
        private TStaff _staff = null;
        public TStaff staff
        {
            get { return _staff; }
            set { _staff = value; }
        }
        public CStaffWrap()
        {
            _staff = new TStaff();
        }
        public CStaffWrap(TStaff s)
        {
            _staff = s;
        }
        public int FId
        {
            get { return _staff.FId; }
            set { _staff.FId = value; }
        }
        [DisplayName("姓名")]
        public string FName
        {
            get { return _staff.FName; }
            set { _staff.FName = value; }
        }
        [DisplayName("電子信箱")]
        public string FEmail
        {
            get { return _staff.FEmail; }
            set { _staff.FEmail = value; }
        }
        [DisplayName("密碼")]
        public string FPassword
        {
            get { return _staff.FPassword; }
            set { _staff.FPassword = value; }
        }
        [DisplayName("管理職位")]
        public string FRole
        {
            get { return _staff.FRole; }
            set { _staff.FRole = value; }
        }
        [DisplayName("手機號碼")]
        public string? FPhone
        {
            get { return _staff.FPhone; }
            set { _staff.FPhone = value; }
        }   
        [DisplayName("創建日期")]
        public DateTime? FCreatedAt
        {
            get { return _staff.FCreatedAt; }
            set { _staff.FCreatedAt = value; }
        }  
        [DisplayName("目前狀態")]
        public bool? FIsActive
        {
            get { return _staff.FIsActive; }
            set { _staff.FIsActive = value; }
        }   
    }
}
