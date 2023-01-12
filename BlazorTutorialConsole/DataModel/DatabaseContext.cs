//using BlazorTutorialConsole.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorTutorialConsole.DataModel;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-572AFVT;Initial Catalog=BT;Integrated Security=True");
    }
    // this is our tables in virtually form
    public DbSet<BlazorTutorialConsole.Model.Horse> Horse { get; set; } //Our Horse table....
  
}
