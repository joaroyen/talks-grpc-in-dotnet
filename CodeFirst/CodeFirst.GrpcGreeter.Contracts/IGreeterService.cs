using System.ServiceModel;
using ProtoBuf.Grpc;

namespace CodeFirst.GrpcGreeter.Contracts;

[ServiceContract]
public interface IGreeterService
{
    [OperationContract]
    Task<HelloResponse> SayHelloAsync(HelloRequest request, CallContext context = default);
}