using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PatinhasQueBrilham.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatinhasQueBrilham.Repository
{
    public class PatinhasContext : DbContext
    {
        public PatinhasContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Reserva> reserva { get; set; }
        public DbSet<AnimaisAdocao> adocao { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Apoio> apoio { get; set; }
        public DbSet<Capa> capa { get; set; }
        public DbSet<IntermediadorAdocao> intermediador { get; set; }
        public DbSet<Adotante> adotante { get; set; }
        public DbSet<AdotanteAnimalAdocao> adotanteAnimalAdocao { get; set; }
        public DbSet<Settings> settings { get; set; }
    }
}
