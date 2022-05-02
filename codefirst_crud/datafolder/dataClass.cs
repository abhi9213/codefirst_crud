using codefirst_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace codefirst_crud.datafolder
{
    public class dataClass:DbContext
    {
        public dataClass(DbContextOptions<dataClass> options):base(options)
        {

        }
        public DbSet<empClass> emptable  { get; set; }
    }
}
