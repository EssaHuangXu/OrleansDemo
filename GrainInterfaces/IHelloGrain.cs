namespace GrainInterfaces;

public interface IHelloGrain : IGrainWithIntegerKey
{
	public ValueTask<string> Hello(string greeting);
}