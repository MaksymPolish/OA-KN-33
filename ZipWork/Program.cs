using Microsoft.Extensions.DependencyInjection;
using ZipWork.Services;
using ZipWork.Services.CommandManager;

var serviceProvider = new ServiceCollection()
    .RegisterServices()
    .BuildServiceProvider();
var invoker = new Invoker(serviceProvider);

invoker.Run();