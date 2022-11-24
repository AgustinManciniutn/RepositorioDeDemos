using sigmaHashAlpha.Models.Products;

namespace sigmaHashAlpha.Models
{
    public class CacheModel
    {
        public List<Motherboard> motherboards { get; set; }
        public List<CPU> cpus { get; set; }
        public List<GPU> gpus { get; set; }
        public List<RAM> rams { get; set; }
        public List<PSU> psus { get; set; }
        public List<Mouse> mouses { get; set; }
        public List<Keyboard> keyboards { get; set; }
        public List<Storage> storages { get; set; }
        public List<GMonitor> monitors { get; set; }
        public List<Case> cases { get; set; }
        public List<Miscellaneous> miscellaneous { get; set; }
    }
}
