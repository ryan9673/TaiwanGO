using TaiwanGo.Models.Wrap;

namespace TaiwanGo.ViewModels
{
    public class CCategoryDetails
    {
      
        public CAttractionCategoryWrap Category { get; set; }
        // 該分類底下的所有景點 (多筆)
        public List<CAttractionWrap> AttractionsList { get; set; }

        // 新增主要景點屬性，預設取 AttractionsList 的第一筆，用在view中顯示主要景點
        public CAttractionWrap MainAttraction
        {
            get
            {
                return AttractionsList?.FirstOrDefault() ?? new CAttractionWrap();
            }
        }
        public CCategoryDetails()
        {
            Category = new CAttractionCategoryWrap();
            AttractionsList = new List<CAttractionWrap>();
        }

    }
}
