using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogApi.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Price { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }

        [Required]
        public float? Stock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public Category? Category { get; set; }
    }
}
