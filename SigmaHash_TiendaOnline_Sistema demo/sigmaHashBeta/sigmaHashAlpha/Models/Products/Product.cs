 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Products;

public class Product
{

    [Key]
    [Column(Order = 1)]
    public string? Id { get; set; }

    [Column(Order = 2)]
    [Required(ErrorMessage = "Brand is required.")]
    public string Brand { get; set; }

    [Column(Order = 3)]
    [Required(ErrorMessage = "Model is required.")]
    public string Model { get; set; }

    [Column(Order = 4)]
    public string? Category { get; set; }

    [Required]
    [Column(Order = 5)]
    [DisplayFormat(DataFormatString = "{0:C0}")]

    public float Price { get; set; }

    [Required]
    [Column(Order = 6)]
    public short? Warranty { get; set; }

    [Column(Order = 7)]
    public bool ShipsNational { get; set; }
    [Column(Order = 8)]
    public bool ShipsInternational { get; set; }

    [NotMapped]
    public List<string>? ImagesPaths { get; set; }

    [NotMapped]
    public List<IFormFile>? Images { get; set; }

}

