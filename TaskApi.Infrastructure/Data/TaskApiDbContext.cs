using Microsoft.EntityFrameworkCore;
using TaskApi.Domain.Entities;
using TaskApi.Infrastructure.Data.Configurations;

namespace TaskApi.Infrastructure.Data;

public class TaskApiDbContext: DbContext
{
    public TaskApiDbContext(DbContextOptions<TaskApiDbContext> options) : base(options) { }
    
    public DbSet<TaskItem?> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TaskConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}