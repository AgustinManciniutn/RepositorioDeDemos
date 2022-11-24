using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Models
{
	public class ListAndFilter
	{
		public List<ProductList> List { get; set; }
		public FilterAndPage Filter { get; set; }
		public bool? Filtered { get; set; } = false;
		public string? FilterText { get; set;} = string.Empty;
		public int? Page { get; set; }
		public int? PageCount { get; set; }
	}
}
