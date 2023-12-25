using AdvantShop.DataAccess.Data;
using AdvantShop.DataAccess.Data.Entities;
using AdvantShop.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AdvantsShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AdvantShopDbContext _context;
        public AccountController(AdvantShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authorization(AuthorizationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var passwordHash = GetHashString(model.Password);

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == model.Email.ToLower() && u.Password == passwordHash);

            if (user == null)
            {
                ModelState.AddModelError(nameof(AuthorizationViewModel.Email), "Такого пользователя не существует");

                return View(new AuthorizationViewModel()
                {
                    Email = model.Email
                });
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return RedirectToActionPermanent("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                FirstName = model.FirstName,
                SecondName = model.LastName,
                Email = model.Email.ToLower(),
                Phone = model.PhoneNumber,
                Password = GetHashString(model.Password),
                Cart = new Cart()
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Authorization));
        }

        private string GetHashString(string s)
        {
            using HashAlgorithm algorithm = SHA256.Create();

            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(s));

            return BitConverter.ToString(bytes);
        }
    }
}