using System.Security.Claims;

namespace AdvantShop.Web.Helpers
{
    public static class PrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            var claim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                throw new NullReferenceException();
            }

            return int.Parse(claim.Value);
        }
    }
}
