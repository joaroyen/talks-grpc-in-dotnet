using CodeFirst.GrpcGreeter.Contracts;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7036");
var client = channel.CreateGrpcService<IGreeterService>();

var reply = await client.SayHelloAsync(
    new HelloRequest
    {
        Name = "GreeterClient"
    });

Console.WriteLine($"Greeting: {reply.Message}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();