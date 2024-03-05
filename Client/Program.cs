using GrainInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Serialization.Invocation;

namespace OrleansDemo.Client;

public static class Program
{
	public static async Task Main( string[] args )
	{
		IHostBuilder build = Host.CreateDefaultBuilder( args )
			.UseOrleansClient( client =>
			{
				client.UseLocalhostClustering();
			} )
			.ConfigureLogging( logging => logging.AddConsole() )
			.UseConsoleLifetime();

		var host = build.Build();
		await host.StartAsync();

		var client = host.Services.GetRequiredService<IClusterClient>();
		IHelloGrain helloGrain = client.GetGrain<IHelloGrain>( 0 );
		string response = await helloGrain.Hello( "Hi!" );

		Console.WriteLine( $"""
			{response}

			Press any key to exit...
			""" );

		Console.ReadKey();
		await host.StopAsync();
	}
}