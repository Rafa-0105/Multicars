using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Multicars.Models.BD;

namespace Multicars.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<Carros> carros { get; set; }
        public DbSet<Grupos> grupos { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Alugueis> alugueis { get; set; }
        public DbSet<Login> login { get; set; }


    }
}