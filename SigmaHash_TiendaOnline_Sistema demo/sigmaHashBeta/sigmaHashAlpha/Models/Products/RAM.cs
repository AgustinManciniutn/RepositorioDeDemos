using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sigmaHashAlpha.Models.Products
{
    public class RAM : Product
    {
		//GENERAL
		[DisplayName("Capacidad")]
        public short? Capacity {get; set;}

        [DisplayName("Velocidad")]
        public short? Speed {get; set;}
        [DisplayName("Tipo")]
        public string? Type {get; set;}

        public double? Voltage {get; set;}
		// COOLING

		[DisplayName("Heat Sink")]
        public bool HeatSink {get; set;}



    }

}
