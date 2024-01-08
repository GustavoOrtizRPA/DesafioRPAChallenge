using Dominio.Interfaces;
using Executor;
using Infraestrutura.Services.ChromeService;
using Infraestrutura.Services.OutlookService;
using Infraestrutura.Services.RpaChallengeService;
using Infraestrutura.Services.WindowsService;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IWebDriverService, ChromeService>();
serviceCollection.AddSingleton<IRpaChallengeService, RpaChallengeService>();
serviceCollection.AddSingleton<IWindowsService, WindowsService>();
serviceCollection.AddSingleton<IOutlookService, OutlookService>();

serviceCollection.AddSingleton<IRunner, Runner>();

serviceCollection.BuildServiceProvider()
    .GetService<IRunner>()?.Run();