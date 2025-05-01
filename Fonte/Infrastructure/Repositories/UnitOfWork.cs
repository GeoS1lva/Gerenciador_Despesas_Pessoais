using GerenciadorDespesasPessoais.Domain.Interfaces;
using GerenciadorDespesasPessoais.Infrastructure.Context;

namespace GerenciadorDespesasPessoais.Infrastructure.Repositories
{
    public class UnitOfWork(SqlServerDbContext context) : IUnitOfWork
    {
        private readonly SqlServerDbContext _context = context;
        public IDespesasRepository DespesasRepository { get; } = new DespesasRepository(context);
        
        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
