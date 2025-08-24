using System.ComponentModel;
using TaiwanGo.Models.Domain;

namespace TaiwanGo.Models.Wrap
{
    public class CAttractionCategoryWrap
    {
        private TAttractionCategory _attractioncategory = null;
        public TAttractionCategory attractioncategory
        {
            get { return _attractioncategory; }
            set { _attractioncategory = value; }
        }
        public CAttractionCategoryWrap()
        {
            _attractioncategory = new TAttractionCategory();
        }
        public CAttractionCategoryWrap(TAttractionCategory a)
        {
            _attractioncategory = a;
        }
        public int FId
        {
            get { return _attractioncategory.FId; }
            set { _attractioncategory.FId = value; }
        }
        [DisplayName("景點分類")]
        public string FCategoryName
        {
            get { return _attractioncategory.FCategoryName; }
            set { _attractioncategory.FCategoryName = value; }
        } 
    }
}
