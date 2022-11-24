using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sigmaHashAlpha.Models.Products;

public class CPU : Product
{

    //GENERAL
    [DisplayName("Serie")]
    public string? Series { get; set; }
    public string? Socket { get; set; }

    [DisplayName("Núcleos")]
    public short? Cores { get; set; }

    [DisplayName("Frequencia")]
    public double? Frequency { get; set; }

    [DisplayName("Chipset gráfico")]
    public string? GPUChipset { get; set; }


    public short? Threads { get; set; }

    [DisplayName("Frequencia Turbo")]
    public double? TurboFrequency { get; set; }

    //COOLING

    [DisplayName("Potencia de Diseño Térmico")]
    public short? TDP { get; set; }

    [DisplayName("Incluye Cooler")]
    public bool IncludesCooler { get; set; }

    //MEMORY

    [DisplayName("Memoria L3")]
    public short? L3 { get; set; }

    //public CPU(string? id, string brand, string model, string? category) : base(id, brand, model, category) { } 



}
