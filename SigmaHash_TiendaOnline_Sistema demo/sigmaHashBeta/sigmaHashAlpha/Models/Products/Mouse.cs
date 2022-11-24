using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products
{
    public class Mouse : Product
    {
		//GENERAL
		[DisplayName("Cantidad de botones")]
        public short? ButtonAmount { get; set; }
        [DisplayName("Tipo de Switchs")]
        public string? SwitchesType { get; set; }
        [DisplayName("Tipo de sensor")]
        public string? SensorType { get; set; }
   
        public bool Wireless { get; set; }
        [DisplayName("Cableado")]
        public bool Wired { get; set; }

        //PERFORMANCE
        [DisplayName("Dpi Ajustable")]
        public bool AdjustableDPI { get; set; }
        [DisplayName("Dpi mínimo")]
        public short? MinimumDPI { get; set; }
        [DisplayName("Dpí máximo")]
        public short? MaximumDPI { get; set; }

        //DIMENTIONS
        [DisplayName("Peso")]
        public short? Weight { get; set; }
        [DisplayName("Pesas intercambiables")]
        public bool CanChangeWeights { get; set; }
        [DisplayName("Ancho")]
        public short? Width { get; set; }
        [DisplayName("Largo")]
        public short? lenght { get; set; }

    }
}
