using sigmaHashAlpha.Models.Filter;

namespace sigmaHashAlpha.Models.ViewModels.CriteriaViewModel
{
    public class CriteriaViewModel
    {
        public Criteria Criteria { get; set; }
        public Dictionary<int,string> Categories {get;set;}
        public Dictionary<int,string> Attributes {get;set;}
        public List<Subcategory>? Subcategories { get; set; }
    }
}
