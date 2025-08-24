using System.ComponentModel;
using TaiwanGo.Models.Domain;

namespace TaiwanGo.Models.Wrap
{
    public class CAttractionWrap
    {
        private TAttraction _attraction = null;
        public TAttraction attraction
        {
            get { return _attraction; }
            set { _attraction = value; }
        }
        public CAttractionWrap()
        {
            _attraction = new TAttraction();
        }
        public CAttractionWrap(TAttraction a)
        {
            _attraction = a;
        }
        public int FId
        {
            get { return _attraction.FId; }
            set { _attraction.FId = value; }
        }
        public int FCategoryId
        {
            get { return _attraction.FCategoryId; }
            set { _attraction.FCategoryId = value; }
        }
        [DisplayName("景點名稱")]
        public string AttractionName
        {
            get { return _attraction.AttractionName; }
            set { _attraction.AttractionName = value; }
        }
        [DisplayName("景點描述")]
        public string? FDescription
        {
            get { return _attraction.FDescription; }
            set { _attraction.FDescription = value; }
        }
        [DisplayName("景點地區")]
        public string? FLocation
        {
            get { return _attraction.FLocation; }
            set { _attraction.FLocation = value; }
        }
        [DisplayName("景點圖片")]
        public string? FImage
        {
            get { return _attraction.FImage; }
            set { _attraction.FImage = value; }
        }
        public IFormFile Photo { get; set; }
        // 給下拉選單顯示用
        public string? FCategoryName { get; set; }
    }
}
