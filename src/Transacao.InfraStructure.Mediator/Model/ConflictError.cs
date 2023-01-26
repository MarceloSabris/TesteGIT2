namespace  Transacao.InfraStructure.Mediator.Model
{ 
    public class ConflictError : Error
    {
        public ConflictError(ErrorCatalogEntry catalogEntry) : base(catalogEntry)
        {
        }

        public ConflictError(string code, string message) : base(code, message)
        {
        }
    }
}