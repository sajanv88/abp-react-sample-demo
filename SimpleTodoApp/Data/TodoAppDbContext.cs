using Microsoft.EntityFrameworkCore;
using SimpleTodoApp.Entities;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace SimpleTodoApp.Data;

public class TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : AbpDbContext<TodoAppDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Todo>(b =>
        {
            b.ToTable("Todos");
            
            b.ConfigureByConvention();

            b.Property(x => x.Title).IsRequired().HasMaxLength(120);
            b.Property(x => x.Description).HasMaxLength(1000);
            b.Property(x => x.IsCompleted).HasDefaultValue(false);
            
        });
    }

    public DbSet<Todo> Todos { get; set; }
}