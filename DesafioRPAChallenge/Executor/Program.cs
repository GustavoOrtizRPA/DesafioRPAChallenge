using Dominio.Interfaces;
using Executor;
using Infraestrutura.Services.ChromeService;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IWebDriverService, ChromeService>();
serviceCollection.AddSingleton<IWindowService, WindowService>();
serviceCollection.AddSingleton<IRunner, Runner>();

serviceCollection.BuildServiceProvider()
    .GetService<IRunner>()?.Run();