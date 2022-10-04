namespace CodeFirst.GrpcGreeter.Contracts;

[DataContract]
public class Header
{
    [DataMember(Order = 1)]
    public Version? Version { get; set; }
    
    [DataMember(Order = 2)]
    public Guid CorrelationId { get; set; }
}