namespace AdvantShop.DataAccess.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public ICollection<ProductCart> Products { get; set; } = new HashSet<ProductCart>();
    }
}
