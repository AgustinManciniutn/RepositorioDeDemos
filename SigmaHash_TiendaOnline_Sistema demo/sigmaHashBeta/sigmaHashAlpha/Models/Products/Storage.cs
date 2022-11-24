using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products
{
    public class Storage : Product
    {
		//GENERAL
		[DisplayName("Capacidad de almacenamiento")]
        public short? StorageSize { get; set; }

		[DisplayName("Tipo de conexión")]
        public string? ConnectionType { get; set; }
		[DisplayName("Consumo")]
        public short? Consumption { get; set; }
        [DisplayName("Tipo")]
        public string? StorageType { get; set; }
        
        //PERFORMANCE
        public short? RPM { get; set; }


        //public Storage(string? id, string brand, string model, string? category) : base(id, brand, model, category) { }

    }
}
