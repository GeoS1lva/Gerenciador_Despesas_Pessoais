namespace GerenciadorDespesasPessoais.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IDespesasRepository DespesasRepository { get; }
        Task SaveChangesAsync();
    }
}
