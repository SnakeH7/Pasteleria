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
    }
}
