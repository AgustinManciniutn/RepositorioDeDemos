using sigmaHashAlpha.Models.Architecture;
using sigmaHashAlpha.Models.Filter;


namespace sigmaHashAlpha.Models.ViewModels
{
    public class ListAndCriteria
    {
        public List<Product> List { get; set; } = new List<Product>();
        public Criteria? Criteria { get; set; } = new Criteria();
    }
}
