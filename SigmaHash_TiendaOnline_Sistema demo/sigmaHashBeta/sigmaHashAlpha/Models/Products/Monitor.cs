using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products
{
    public class GMonitor : Product
    {
        //SCREEN
        [DisplayName("Tipo de retroiluminación")]
        public string? RetroilluminationType { get; set; }
        [DisplayName("Pantalla curva")]
        public bool IsCurved { get; set; }

        [DisplayName("Pulgadas")]
        public short? Inches { get; set; }
        [DisplayName("Resolución Máxima")]
        public string? MaxResolution { get; set; }
        [DisplayName("Refresh rate")]
        public short? RefreshRate { get; set; }
        [DisplayName("NVidia GSync")]
        public bool NvidiaGSync { get; set; }
        [DisplayName("Amd Freesyncx")]
        public bool AMDFreeSync { get; set; }
        [DisplayName("Pantalla Touch")]
        public bool TouchScreen { get; set; }

        //CONNECTIVITY
        public short? HDMI { get; set; }
        public short? DVI { get; set; }
        public short? VGA { get; set; }

        public short? DisplayPort { get; set; }
        [DisplayName("Puertos USB 2.0")]
        public short? Usb20Ports { get; set; }
        [DisplayName("Puertos USB 3.0")]
        public short? Usb30Ports { get; set; }
        [DisplayName("Puertos USB 3.1")]
        public short? Usb31Ports { get; set; }
        [DisplayName("Mini Display Port")]
        public short? MiniDisplayPort { get; set; }

        //DIMENSIONS
        [DisplayName("Largo")]
        public short? Width { get; set; }
        [DisplayName("Altura")]
        public short? Height { get; set; }
        

        //public GMonitor(string? id, string brand, string model, string? category) : base(id, brand, model, category) { }

    }
}
