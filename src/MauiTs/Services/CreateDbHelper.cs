using MauiTs.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MauiTs.Services;

public static class CreateDbHelper
{

    public static string CreateTsDirectory()
    {
        var dbPath = Path.Combine(
         FileSystem.Current.AppDataDirectory, "atividades_data.db");
        var directoryName = Path.GetDirectoryName(dbPath)
        ?? throw new Exception("Erro ao criar pasta.");

        Directory.CreateDirectory(directoryName);
        return dbPath;
    }

    public static void ApplyDatabaseMigrations(this MauiApp mauiApp)
    {
        var dbPath = CreateTsDirectory();

        var optionsBuilder = new DbContextOptionsBuilder<TsContext>();
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        //var migrator = context.Database.GetInfrastructure().GetRequiredService<IMigrator>();
        //migrator.Migrate("20230129140515_AdicaoDePrecoUnitarioContaEvento");

        var context = new TsContext(optionsBuilder.Options);

        context.Database.Migrate();
    }
}
