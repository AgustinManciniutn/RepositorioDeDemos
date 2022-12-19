namespace sigmaHashAlpha.Models.Filter
{
    public class Criteria
    {
        public string? Category { get; set; }
        public int? CategoryId { get; set; }
        public List<string>? Attributes { get; set; }
    
        public List<Subcategory>? SelectedAttributes { get; set; } = new List<Subcategory>();

        public string? Filters { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SearchFilter { get; set; }
        public int? Page { get; set; } = 1;
        public int PageCount { get; set; } = 1;
        public string? Sort { get; set; }
        public bool? SortReverse { get; set; }
        public string? CurrentPage { get; set; }
    }
}
