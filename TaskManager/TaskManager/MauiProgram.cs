﻿using Microsoft.Extensions.Logging;
using TaskManager;

namespace TaskManagement
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureMopups();
            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);

            builder.Services.AddTransient<TaskDbContext>();
            builder.Services.AddSingleton<UserRepository>();
            builder.Services.AddSingleton<TaskRepository>();
            builder.Services.AddSingleton<TeamRepository>();

            builder.Services.AddSingleton<AppShell>();
            builder.Services.AddTransient<LoginViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
