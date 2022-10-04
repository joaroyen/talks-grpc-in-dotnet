namespace CodeFirst.GrpcGreeter.Contracts;

[DataContract]
public class HelloRequest
{
    [DataMember(Order = 1)]
    public Header? Header { get; set; }
    
    [DataMember(Order = 2)]
    public string? Name { get; set; }
}