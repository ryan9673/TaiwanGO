using System.ComponentModel;
using TaiwanGo.Models.Domain;

namespace TaiwanGo.Models.Wrap
{
    public class CUserWrap
    {
        private TUser _user = null;
        public TUser staff
        {
            get { return _user; }
            set { _user = value; }
        }
        public CUserWrap()
        {
            _user = new TUser();
        }
        public CUserWrap(TUser u)
        {
            _user = u;
        }
        public int FId
        {
            get { return _user.FId; }
            set { _user.FId = value; }
        }
        [DisplayName("姓名")]
        public string FName
        {
            get { return _user.FName; }
            set { _user.FName = value; }
        }
        [DisplayName("電子信箱")]
        public string FEmail
        {
            get { return _user.FEmail; }
            set { _user.FEmail = value; }
        }
        [DisplayName("密碼")]
        public string FPassword
        {
            get { return _user.FPassword; }
            set { _user.FPassword = value; }
        }
        [DisplayName("生日")]
        public DateOnly? FBirthDate
        {
            get { return _user.FBirthDate; }
            set { _user.FBirthDate = value; }
        }
        [DisplayName("性別")]
        public string? FGender
        {
            get { return _user.FGender; }
            set { _user.FGender = value; }
        }

        [DisplayName("手機號碼")]
        public string? FPhone
        {
            get { return _user.FPhone; }
            set { _user.FPhone = value; }
        }
        [DisplayName("創建日期")]
        public DateTime? FCreatedAt
        {
            get { return _user.FCreatedAt; }
            set { _user.FCreatedAt = value; }
        }
        [DisplayName("目前狀態")]
        public bool? FIsActive
        {
            get { return _user.FIsActive; }
            set { _user.FIsActive = value; }
        }
    }
}
