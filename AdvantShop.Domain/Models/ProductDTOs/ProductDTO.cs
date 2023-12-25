using System.ComponentModel.DataAnnotations;

namespace AdvantShop.Domain.Models.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public bool InStock => Stock > 0;

        public IReadOnlyCollection<string> Images { get; set; }

        [Range(0, 5)]
        public int Rating { get; set; }
        public float Price { get; set; }

        public string FormattedPrice => Price.ToString("#,##0").Replace(",", " ");
    }
}