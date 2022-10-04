using GreetApi;
using GreetApi.Common;
using Grpc.Core;
using Grpc.Net.Client;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7008");
var client = new Greeter.GreeterClient(channel);

var cancellationTokenSource = new CancellationTokenSource();

Console.WriteLine("Press 1 for request/response");
Console.WriteLine("Press 2 for streaming responses");

switch (Console.ReadKey().Key)
{
    case ConsoleKey.D1:
        await SayHello();
        break;
    case ConsoleKey.D2:
        await StreamHello(cancellationTokenSource.Token);
        break;
    default:
        return;
}

async Task SayHello()
{
    Console.WriteLine();
    
    var response = await client.SayHelloAsync(
        new HelloRequest
        {
            Header = new Header
            {
                // Implicit cast
                Version = new System.Version(1, 0),
                // Need to document on how uuids are represented on the wire
                // In this case we serialize to string with hyphens without enclosing curly braces
                CorrelationId = Guid.NewGuid().ToString("D")
            },
            Name = "GreeterClient",
            NullableString = null,
            Type = HelloType.Two
        });

    Console.WriteLine($"Greeting: {response.Message}");
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}

async Task StreamHello(CancellationToken cancellationToken)
{
    Console.WriteLine();

    try
    {
        var asyncServerStreamingCall = client.SayHelloServerStream(
            new HelloRequest { Name = "GreeterClient" }, 
            cancellationToken: cancellationToken);

        var responseStream = asyncServerStreamingCall.ResponseStream;
        await foreach (var response in responseStream.ReadAllAsync(cancellationToken))
        {
            Console.WriteLine($"Greeting: {response.Message}");
        }
    }
    catch (RpcException e) when (e.StatusCode == StatusCode.Aborted)
    {
        Console.WriteLine("Stream was aborted");
        throw;
    }
}