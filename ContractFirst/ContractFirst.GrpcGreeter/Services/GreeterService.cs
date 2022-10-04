using GreetApi;
using Grpc.Core;

namespace ContractFirst.GrpcGreeter.Services;

public class GreeterService : Greeter.GreeterBase
{
    public override async Task<HelloResponse> SayHello(
        HelloRequest request, 
        ServerCallContext context)
    {
        return await Task.FromResult(new HelloResponse
        {
            Message = $"Hello {request.Name}"
        });
    }

    public override async Task SayHelloServerStream(
        HelloRequest request, 
        IServerStreamWriter<HelloResponse> responseStream, 
        ServerCallContext context)
    {
        var responseCounter = 1;
        while (!context.CancellationToken.IsCancellationRequested)
        {
            await responseStream.WriteAsync(new HelloResponse
            {
                Message = $"Response {responseCounter++}"
            });
            await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
        }
    }
}