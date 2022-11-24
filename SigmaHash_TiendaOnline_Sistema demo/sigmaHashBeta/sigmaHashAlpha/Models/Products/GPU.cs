using System.ComponentModel;

namespace sigmaHashAlpha.Models.Products;

public class GPU : Product
{
    //GENERAL



    //CONNECTIVITY
    public short? HDMI { get; set; }
    public short? VGA { get; set; }
    public short? DVIdigital { get; set; }
	[DisplayName("Display Ports")]
    public short? DisplayPorts { get; set; }
	[DisplayName("Doble Puente")]
    public bool DoubleBridge { get; set; }
	[DisplayName("USB Type-C")]
    public short? USBtypeC { get; set; }
    [DisplayName("SLI/Crossfirex")]
    public string? SLIorCrossfire { get; set; }

	//DIMENSIONS
	[DisplayName("Ancho")]
    public short? Width { get; set; }
    [DisplayName("Largo")]
    public short? Lenght { get; set; }

    //ENERGY
    [DisplayName("Cant. Pcie 6 pines")]

    public short? Consumption { get; set; }
    [DisplayName("Wataje de fuente recomendado")]
    public short? RecommendedWatts { get; set; }

    //COOLERS Y DISIPADORES

    public bool Backplate { get; set; }

    [DisplayName("VGA Water Cooling")]
    public bool VGAWaterCooling { get; set; }
    [DisplayName("Cantidad de fans")]
    public short? AmountOfCoolers { get; set; }

    //ADDITIONAL
    [DisplayName("Velocidad de memoria")]
    public short? MemorySpeed { get; set; }

    [DisplayName("Tipo de memoria")]
    public string? MemoryType { get; set; }
    [DisplayName("Capacidad de memoria")]
    public short? MemoryCapacity { get; set; }
    [DisplayName("Interfaz de memoria")]
    public short? MemoryInterface { get; set; }
    [DisplayName("Core Turbo Speed")]
    public short? CoreTurboSpeed { get; set; }


    //public GPU(string? id, string brand, string model, string? category) : base(id, brand, model, category) { }

}
