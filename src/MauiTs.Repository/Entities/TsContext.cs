using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MauiTs.Repository.Entities;

public class TsContext : DbContext
{
    public DbSet<Atividade> Atividades => Set<Atividade>();

    public TsContext(DbContextOptions<TsContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TsContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
