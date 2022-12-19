using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Architecture
{
    public class Product
    {

        [Key]
        [Column(Order = 1)]
        public string? ProductId { get; set; }


        [Column(Order = 2)]
        public string? Category { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; }

        [Column(Order = 4)]
        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; }

        public string? MainImage { get; set; }


        [Required]
        [Column(Order = 5)]
        [DisplayFormat(DataFormatString = "{0:C0}")]

        public decimal Price { get; set; }

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
        public IFormFile[]? Images { get; set; }
        public string DateCreated { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString();
        public List<ProductAttribute> ProductAttributes { get; set; }

        [NotMapped]
        public List<Attr> CategoryAttributes { get; set; }
        //[NotMapped]
        //public List<int> CategoriesId { get; set; }
        public Product(string? productId, string? category, string brand, string model, string? mainImage, decimal price, short? warranty, bool shipsNational, bool shipsInternational)
        {
            ProductId = productId;
            Category = category;
            Brand = brand;
            Model = model;
            MainImage = mainImage;
            Price = price;
            Warranty = warranty;
            ShipsNational = shipsNational;
            ShipsInternational = shipsInternational;
        }
        public Product()
        {

        }
    }
}
