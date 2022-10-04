namespace CodeFirst.GrpcGreeter.Contracts;

[DataContract]
public class HelloResponse
{
    [DataMember(Order = 1)]
    public string? Message { get; set; }
}