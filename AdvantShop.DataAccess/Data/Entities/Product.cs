namespace AdvantShop.DataAccess.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> ImagePaths { get; set; } = new HashSet<string>();
        public int Stock { get; set; }
        public float Price { get; set; }
        public bool IsNew { get; set; }
        public bool IsBestSeller { get; set; }
        public int Rating { get; set; }
    }
}