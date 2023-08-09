using GRUD_Asp.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace GRUD_Asp.Net.Datos
{
    public class ApplicationDbContext:DbContext//va a heredar de esa clase del entity y agregamos el using
    {
        //Creamos el constructor de la clase
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { 
        
        }
        //Aca va todos los modelos de las entidades
        public DbSet<Contact> Contacts { get; set; }

    }
}
