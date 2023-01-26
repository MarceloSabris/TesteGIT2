namespace Transacao.InfraStructure.Mediator.Model
{
    public interface IResult
    {
        object? Value { get; }
        Error? Error { get; }
    }
  
}