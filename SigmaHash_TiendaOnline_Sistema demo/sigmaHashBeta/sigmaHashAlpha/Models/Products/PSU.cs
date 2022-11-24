using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products
{
    public class PSU : Product
    {
        [DisplayName("Certificación")]
        public string? Certification { get; set; }
        [DisplayName("Watts nominales")]
        public short? WattsNominal { get; set; }
        [DisplayName("Watts reales")]
        public short? WattsReal { get; set; }
        [DisplayName("Formato")]
        public string? Format { get; set; }

        public bool HybridMode { get; set; }
        [DisplayName("Tipo de cableado")]
        public string? CableType { get; set; }
        [DisplayName("Fuente Digital")]
        public bool DigitalPSU { get; set; }

        //CABLES
        [DisplayName("Conector de CPU 4 Pins")]
        public short? CPU4Pin { get; set; }
        [DisplayName("Conector de CPU 4 Pins Plus")]
        public short? CPU4PinPlus { get; set; }
        [DisplayName("Conector de 24 Pins")]
        public short? Pin24 { get; set; }
        [DisplayName("Conector PCI 6 Pins")]
        public short? PCI6Pin { get; set; }
        [DisplayName("Conector PCI 2 Pins Plus")]
        public short? PCI2PinPlus { get; set; }
        [DisplayName("Conector Sata")]
        public short? SataConnection { get; set; }
        [DisplayName("Conector Molex")]
        public short? MolexConnection { get; set; }
        [DisplayName("Conectores Floppy")]
        public short? FloppyConnection { get; set; }

        //public PSU(string? id, string brand, string model, string? category) : base(id, brand, model, category) { }

    }
}
