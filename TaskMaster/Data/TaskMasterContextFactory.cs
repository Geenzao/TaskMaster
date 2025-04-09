using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskMaster.Models;

//THIS FILE IS USED BY EF CORE AND NOT SUPPOSED TO BE USED BY MAUI
public class TaskMasterContextFactory : IDesignTimeDbContextFactory<TaskMasterContext>
{
  public TaskMasterContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<TaskMasterContext>();

    optionsBuilder.UseMySql(
        "server=localhost;port=3306;user=root;password=;database=taskmanager",
        new MySqlServerVersion(new Version(8, 0, 36))
    );

    return new TaskMasterContext(optionsBuilder.Options);
  }
}