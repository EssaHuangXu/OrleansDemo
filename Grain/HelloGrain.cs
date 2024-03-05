using GrainInterfaces;
using Microsoft.Extensions.Logging;

namespace Grains;

public class HelloGrain( ILogger<IHelloGrain> logger ) : Grain, IHelloGrain
{
	private readonly ILogger<IHelloGrain> _logger = logger;

	ValueTask<string> IHelloGrain.Hello( string greeting )
	{
		_logger.LogInformation( """
            SayHello message received: greeting = "{Greeting}"
            """,
			greeting );

		return ValueTask.FromResult( $""""
			Client said "{greeting}", so HelloGrain says : Hello!
			"""" );
	}
}
