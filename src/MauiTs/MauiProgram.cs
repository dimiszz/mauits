using MauiTs.Repository.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MauiTs.Repository.Interfaces;
using MauiTs.Repository.Repos;
using Microsoft.AspNetCore.Components.RenderTree;
using MauiTs.Services;
using Microsoft.Extensions.Options;
using Microsoft.Maui.Hosting;


namespace MauiTs
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            var dbPath = CreateDbHelper.CreateTsDirectory();

            builder.Services.AddDbContext<TsContext>(options => 
            {
                options.UseSqlite($"Data Source={dbPath}");
            });

            builder.Services.AddScoped<AtividadeRepository>();
            builder.Services.AddScoped<IAtividadeService, AtividadeService>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            MauiApp mauiBuilder =  builder.Build();

            mauiBuilder.ApplyDatabaseMigrations();
            return mauiBuilder;
        }
    }
}
