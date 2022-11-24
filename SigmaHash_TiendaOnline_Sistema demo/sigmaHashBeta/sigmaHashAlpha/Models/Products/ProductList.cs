using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Products;

public class ProductList
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

    public string? MainImage { get; set; }

    [Column(Order = 4)]
    public string? Category { get; set; }

    [Required]
    [Column(Order = 5)]
    [DisplayFormat(DataFormatString = "{0:C0}")]

    public float Price { get; set; }

    [Required]
    [Column(Order = 6)]
    public short? Warranty { get; set; }

    public bool ShipsNational { get; set; }
    public bool ShipsInternational { get; set; }
    public int Stock { get; set; } = 0;
    public int VisitCounter { get; set; } = 0;
    public int SoldCounter { get; set; } = 0;
    public float? Popularity { get; set; } 

    [NotMapped]
    public List<string>? ImagesPaths { get; set; }

    [NotMapped]
    public List<IFormFile>? Images { get; set; }
    public string DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString();

}

