namespace AdvantShop.Domain.Models.CartDTOs
{
    public class SetCartItemAmountDTO
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
    }
}
