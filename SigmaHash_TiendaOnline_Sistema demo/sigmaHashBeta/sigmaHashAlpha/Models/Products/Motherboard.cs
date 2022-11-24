using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sigmaHashAlpha.Models.Products;

public class Motherboard : Product
{
    //GENERAL
    public string Platform { get; set; }
    public string? Socket { get; set; }

    //CONECTIVITY

    public short? PCIE16Xslots { get; set; }
    public short? PCIE1Xslots { get; set; }
    public short? MultiGPU { get; set; }
    public short? SATAports { get; set; }
    public short? VGAoutputs { get; set; }
    public short? HDMIoutputs { get; set; }
    public short? DIVoutputs { get; set; }
    public short? DisplayPorts { get; set; }
    public short? M2slots { get; set; }
    public string? BuiltInWifi { get; set; }
    public string? RGBconnection { get; set; }
    [DisplayName("Cantidad de puertos USB 2.0")]
    public short? USB20 { get; set; }
    public short? USB30 { get; set; }
    public short? USB31 { get; set; }
    public short? USB32 { get; set; }
    public short? USBtypeC { get; set; }
    public short? PCIE4X { get; set; }
    public short? M2SATA { get; set; }
    public short? M2nvme { get; set; }

    //SIZE
    public string? factor { get; set; }

    //ENERGY
    public short? MaxCpuWatts { get; set; }
    public short? CPU4pins { get; set; }
    public short? CPU4pinsplus { get; set; }
    public short? pins24   {get;set;}
    public short? consumption { get; set; }

    //MEMORY

    public short? DDRslots { get; set; }
    public short? DDR2slots { get; set; }
    public short? DDR3slots { get; set; }
    public short? DDR4slots { get; set; }
    public short? DDR5slots { get; set; }

    //SOUND
    public string? SoundCard { get; set; }

    //public Motherboard(string? id, string brand, string model, string? category) : base(id, brand, model, category) { }

}
