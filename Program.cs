using HelloWorldOrleansAFPE.CustomGrain;
using HelloWorldOrleansAFPE.HelloGrain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Configure the host
using var host = new HostBuilder()
    .UseOrleans(builder => builder.UseLocalhostClustering())
    .Build();

// Start the host
await host.StartAsync();

// Get the grain factory
var grainFactory = host.Services.GetRequiredService<IGrainFactory>();
menu:
Console.WriteLine($"""
   Presiona 1 para utilizar el Grain de saludo.
   Presiona 2 para utilizar un Grain Custom.
""");

var input = Console.ReadLine();
var result = "";
Console.WriteLine();

if(input == "1")
{
    var grain = grainFactory.GetGrain<IHelloGrain>("prueba");
    result = await grain.SayHello("esta es mi primera prueba de un Grain.");
} else if(input == "2")
{
    var grain = grainFactory.GetGrain<ICustomGrain>("custom");
    result = await grain.CustomString();
} else
{
    goto menu;
}

Console.WriteLine($"""
    {result}
    """);
salir:
Console.WriteLine("¿Quieres salir? [S/N]");
var option = Console.ReadLine();

Console.WriteLine();
if (option == "N" || option == "n")
{
    goto menu;
} else if(option != "S" || option == "s")
{
    goto salir;
} else
{
    Console.WriteLine("Saliendo, espere porfavor...");
    await host.StopAsync();
}

