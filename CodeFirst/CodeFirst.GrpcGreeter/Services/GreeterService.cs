using CodeFirst.GrpcGreeter.Contracts;
using ProtoBuf.Grpc;

namespace CodeFirst.GrpcGreeter.Services;

public class GreeterService : IGreeterService
{
    public Task<HelloResponse> SayHelloAsync(HelloRequest request, CallContext context = default)
    {
        return Task.FromResult(new HelloResponse
        {
            Message = $"Hello {request.Name}"
        });
    }
}