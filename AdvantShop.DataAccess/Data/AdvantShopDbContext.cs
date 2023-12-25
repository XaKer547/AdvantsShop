using AdvantShop.DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvantShop.DataAccess.Data
{
    public class AdvantShopDbContext : DbContext
    {
        public AdvantShopDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slide>().HasData(new Slide[]
            {
                new Slide()
                {
                    Id = 1,
                    Title = "Ноутбуки, планшеты и компьютеры",
                    Description = "Верные помощники для удаленки!",
                    ImagePath = "/images/carousel/pc-sell.png",
                },
                new Slide()
                {
                    Id = 2,
                    Title = "Берите выше. iPhone 11",
                    Description = "Дополнительная выгода 6 000 рублей",
                    ImagePath = "/images/carousel/iphone-sell.png"
                },
                new Slide()
                {
                    Id = 3,
                    Title = "Товары для вашего любимца",
                    Description = "По доступным ценам",
                    ImagePath = "/images/carousel/pet-sell.png"
                },
                new Slide()
                {
                    Id = 4,
                    Title = "Модный интернет магазин",
                    Description = "Одежды, обуви и  аксессуаров",
                    ImagePath = "/images/carousel/dress-sell.png",
                },
            });

            modelBuilder.Entity<Article>().HasData(new Article[]
            {
                new Article()
                {
                    Id = 1,
                    Title = "Оставьте отзыв, чтобы помочь другим",
                    Description = "Стильная и независимая. Легко управляйте средствами на вашем счёте. Получайте информацию о ваших финансах, платежах и переводах при помощи сообщений.",
                    ImagePath = "/images/articles/minecraft.png"
                },
                new Article()
                {
                    Id = 2,
                    Title = "Где купить терминал для эквайринга",
                    Description = "Стильная и независимая. Легко управляйте средствами на вашем счёте. Получайте информацию о ваших финансах, платежах и переводах при помощи сообщений.",
                    ImagePath = "/images/articles/terminal.png"
                },
                new Article()
                {
                    Id = 3,
                    Title = "Как выбрать свой идеальный телефон",
                    Description = "Подключите автоплатёж и будьте уверены, что налог оплачен в срок. Вам не придётся тратить время на поиск суммы к уплате в личном кабинете налогоплательщика.",
                    ImagePath = "/images/articles/phones.png"
                }
            });

            modelBuilder.Entity<Product>().Property(p => p.ImagePaths)
                .HasConversion(v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Прогулочная коляска Valco Baby Snap 4",
                    Price = 16790,
                    ImagePaths = new string[]
                    {
                        "/images/new goods/stroller.png"
                    },
                    IsBestSeller = false,
                    IsNew = true,
                    Rating = 4,
                    Stock = 99
                },
                new Product()
                {
                    Id = 2,
                    Name = "Смартфон Xiaomi Mi 9 Lite 6/128GB",
                    Price = 23600,
                    ImagePaths = new string[]
                    {
                        "/images/new goods/xiaomi.png"
                    },
                    IsBestSeller = false,
                    IsNew = true,
                    Rating = 4,
                    Stock = 99
                },
                new Product()
                {
                    Id = 3,
                    Name = "Моноблок 27 Apple iMac Pro",
                    Price = 426000,
                    ImagePaths = new string[]
                    {
                        "/images/new goods/imac.png"
                    },
                    IsBestSeller = false,
                    IsNew = true,
                    Rating = 4,
                    Stock = 99
                },

                new Product()
                {
                    Id = 4,
                    Name = "Краски для сухих помещений",
                    Price = 16790,
                    ImagePaths = new string[]
                    {
                        "/images/bestseller/paint.png"
                    },
                    IsBestSeller = true,
                    IsNew = false,
                    Rating = 4,
                    Stock = 99
                },
                new Product()
                {
                    Id = 5,
                    Name = "Блуза Concepti Mi 9 Lite 6/128GB",
                    Price = 23600,
                    ImagePaths = new string[]
                    {
                        "/images/bestseller/dress.png"
                    },
                    IsBestSeller = true,
                    IsNew = false,
                    Rating = 4,
                    Stock = 99
                },
                new Product()
                {
                    Id = 6,
                    Name = "Диван Лени Textile Rustic",
                    Price = 426000,
                    ImagePaths = new string[]
                    {
                        "/images/bestseller/sofa.png"
                    },
                    IsBestSeller = true,
                    IsNew = false,
                    Rating = 4,
                    Stock = 99
                },
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
