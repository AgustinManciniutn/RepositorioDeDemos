using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products
{
    public class Case : Product
    {
        //GENERAL
        [DisplayName("Factor Motherboard")]
        public string? FactorMother { get; set; }

        [DisplayName("Soporte para PSU en posición superior")]
        public bool TopPositionPSU { get; set; }
        [DisplayName("Ventana")]
        public bool SideWindow { get; set; }
        public string? Color { get; set; }
        public string? RBG { get; set; }
        [DisplayName("Control para RGB")]
        public bool RGBControl { get; set; }

        //CONNECTIVITY
        [DisplayName("USB 2.0 frontal")]
        public short? USB20front { get; set; }
        [DisplayName("USB 3.0 frontal")]
        public short? USB30front { get; set; }
        [DisplayName("USB Type-C")]
        public short? USBTypeC { get; set; }
        [DisplayName("USB Type-C intero")]
        public short? USBTypeCInternal { get; set; }
        [DisplayName("Conexiones de audio frontal")]
        public bool HDFrontAudio { get; set; }

        //DIMENSIONS
        [DisplayName("Ancho")]
        public short? Width { get; set; }
        [DisplayName("Alto")]
        public short? Height { get; set; }
        [DisplayName("Largo")]
        public short? Lenght { get; set; }
        [DisplayName("Ventana")]
        public short? MaxCPUHeight { get; set; }

        //COOLERS 
        [DisplayName("Soportes de Cooler Fan 80mm")]
        public short? Fans80mmSupported { get; set; }
        [DisplayName("Cooler Fan 80mm incluidos")]
        public short? Fans80mmIncluded { get; set; }

        [DisplayName("Soportes de Cooler Fan 120mm")]
        public short? Fans120mmSupported { get; set; }
        [DisplayName("Cooler Fan 120mm incluidos")]
        public short? Fans120mmIncluded { get; set; }

        [DisplayName("Soportes de Cooler Fan 140mm")]
        public short? Fans140mmSupported { get; set; }
        [DisplayName("Cooler Fan 140mm incluidos")]
        public short? Fans140mmIncluded { get; set; }

        [DisplayName("Soportes de Cooler Fan 200mm")]
        public short? Fans200mmSupported { get; set; }
        [DisplayName("Cooler Fan 200mm incluidos")]
        public short? Fans200mmIncluded { get; set; }
        
        [DisplayName("Soporte para radiador de 240mm")]
        public short? Radiator240mmSupport { get; set; }
       
        [DisplayName("Soporte para radiador de 280mm")]
        public short? Radiator280mmSupport { get; set; }
       
        [DisplayName("Soporte para radiador de 360mm")]
        public short? Radiator360mmSupport { get; set; }
        [DisplayName("Soporte para radiador de 420mm")]
        public short? Radiator420mmSupport { get; set; }
    }
}
