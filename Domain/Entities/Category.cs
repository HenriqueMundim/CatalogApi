using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Domain.Entities
{
    public class Category
    {
        public Category() {
            Products = new Collection<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }

        [Required]
        public ICollection<Product>? Products { get; set; }
    }
}
