using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Entities;

namespace TemplateCRUDNet7.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BranchOffice> TableBranchOffices => Set<BranchOffice>();
        public DbSet<Currency> TableCurrency => Set<Currency>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private static void FillData(ModelBuilder modelBuilder)
        {
            var Currencies = new List<Currency>
            {
                new Currency { Id = Guid.NewGuid(), Acronym = "USD", Description = "Dólar estadounidense" },
                new Currency { Id = Guid.NewGuid(), Acronym = "EUR", Description = "Euro" },
                new Currency { Id = Guid.NewGuid(), Acronym = "JPY", Description = "Yen japonés" },
                new Currency { Id = Guid.NewGuid(), Acronym = "GBP", Description = "Libra esterlina" },
                new Currency { Id = Guid.NewGuid(), Acronym = "AUD", Description = "Dólar australiano" },
                new Currency { Id = Guid.NewGuid(), Acronym = "CAD", Description = "Dólar canadiense" },
                new Currency { Id = Guid.NewGuid(), Acronym = "CHF", Description = "Franco suizo" },
                new Currency { Id = Guid.NewGuid(), Acronym = "CNY", Description = "Yuan chino" },
                new Currency { Id = Guid.NewGuid(), Acronym = "SEK", Description = "Corona sueca" },
                new Currency { Id = Guid.NewGuid(), Acronym = "NZD", Description = "Dólar neozelandés" }
            };

            string[] Summaries = new[]
                     {
                 "Suntea", "Boka", "Bonice", "Nutribela10", "Popetas", "Del Fogón", "Ricostilla", "La sopera", "Quipitos"
             };

            var data = Enumerable.Range(1, 5).Select(index => new BranchOffice
            {
                Id = Guid.NewGuid(),
                Code = int.Parse($"000{index}"),
                DateCreated = DateTime.Now.AddDays(index),
                Description = Summaries[Random.Shared.Next(Summaries.Length)],
                Address = $"Address {index}",
                Identification = $"Identification {index}",
                CurrencyId = Currencies.Select(x => x.Id).ToList()[Random.Shared.Next(Currencies.Count)]
            });

            modelBuilder.Entity<Currency>().HasData(Currencies);
            modelBuilder.Entity<BranchOffice>()
            .HasData(data);
        }
    }

}
