using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Entities;

namespace TemplateCRUDNet7.Context
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tasks> TableTasks => Set<Tasks>();
        public DbSet<User> TableUsers => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private static void FillData(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Name = "Diego Parra",Email = "diegop177@hotmail.com", Password = "diego1234" },
                new User { Id = Guid.NewGuid(), Name = "Laura", Email = "laura@gmail.com", Password = "laura1234" },
                new User { Id = Guid.NewGuid(), Name = "Pilar", Email = "pilar@gmail.com", Password = "pilar1234" }
            };

            string[] Summaries = new[]
                     {
                 "hacer el login", "hacer el registro", "generar el jwt", "eliminar una tarea", "agregar una tarea al backlog"
             };

            var data = Enumerable.Range(1, 50).Select(index => new Tasks
            {
                Id = Guid.NewGuid(),
                IsCompleted = index % 2 == 0 ? true : false,
                DateCreated = DateTime.Now.AddDays(index),
                Description = Summaries[Random.Shared.Next(Summaries.Length)],
                NameTask = $"Tarea {index}",
                UserId = users.Select(x => x.Id).ToList()[Random.Shared.Next(users.Count)]
            });

            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Tasks>()
            .HasData(data);
        }
    }

}
