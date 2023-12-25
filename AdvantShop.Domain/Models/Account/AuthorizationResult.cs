namespace AdvantShop.Domain.Models.Account
{
    public class AuthorizationResult
    {
        public bool IsSuccess { get; set; }
        public string? Token { get; set; }
    }
}
