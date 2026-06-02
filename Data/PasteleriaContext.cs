using System;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Models;

namespace Pasteleria.Data
{
    public class PasteleriaContext: DbContext
    {
        //El constructor recibe la configuración de la conexion
        public PasteleriaContext(DbContextOptions<PasteleriaContext> options) : base(options)
        {

        }

        //Aqui se indican las tablas que se deben construir en la base de datos cuando EF viaje hasta SQL Server 
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Postres> Postres { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Detalles> DetallesVentas { get; set; }
    }
}
