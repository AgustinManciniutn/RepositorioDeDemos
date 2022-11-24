using System.ComponentModel.DataAnnotations;

namespace ReactDemo.Models;

public class Product
{

    [MaxLength(20)]
    public string Id { get; set; }

    [MaxLength(150)]
    public string? Brand { get; set; }
    public string? Model { get; set; }
    [MaxLength(100)]
    public string? Category { get; set; }
    public int? Stock { get; set; }
    public decimal? Price { get; set; }
    public string? ImagePath { get; set; }
}
