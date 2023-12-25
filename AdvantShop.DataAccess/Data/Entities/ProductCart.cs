using System.ComponentModel.DataAnnotations.Schema;

namespace AdvantShop.DataAccess.Data.Entities
{
    public class ProductCart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}
