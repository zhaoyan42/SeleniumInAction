using System.Data.Entity;
using TargetMvcApplication.Models;

namespace TargetMvcApplication.Context
{
    public class TargetMvcApplicationContext : DbContext 
    {
        public DbSet<Record> Records { get; set; } 
    }
}