using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products
{
    public class Keyboard : Product
    {
		//GENERAL
		[DisplayName("Tipo de teclado")]
        public string? MechanismType { get; set; }
		[DisplayName("Familia del Switch")]
        public int? SwitchFamily { get; set; }
		[DisplayName("RGB")]
        public bool RGBColor { get; set; }

		//PERFORMANCE
		[DisplayName("Anti-Ghosting")]
        public bool AntiGhosting { get; set; }
		[DisplayName("NKey Rollover")]
        public bool NKeyRollover { get; set; }

		//DIMENSIONS
		[DisplayName("Ancho")]
        public short? width { get; set; }
        [DisplayName("Largo")]
        public short? lenght { get; set; }
        [DisplayName("Peso")]

        //CABLING
        public bool Wireless { get; set;}
        [DisplayName("Cable removible")]
        public bool CanRemoveCable { get; set; }

    }
}
