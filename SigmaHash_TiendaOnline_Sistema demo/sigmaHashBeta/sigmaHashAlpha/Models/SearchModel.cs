using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Models
{
    public class SearchModel
    {
        public Motherboard motherboard { get; set; }
        public CPU cpu { get; set; }
        public GPU gpu { get; set; }
        public RAM ram { get; set; }
        public PSU psu { get; set; }
        public Mouse mouse { get; set; }
        public Keyboard keyboard { get; set; }
        public Storage storage { get; set; }
        public GMonitor monitor { get; set; }
        public Case OneCase { get; set; }
        public Miscellaneous Miscellaneous { get; set; }
    }
}
