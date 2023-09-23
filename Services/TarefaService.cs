using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Services
{

    public class TarefaService : IHostedService, IDisposable
    {
        private readonly OrganizadorContext _context;
        public TarefaService(OrganizadorContext context)
        {
            _context = context;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            //TODO
        }

        public Tarefa ObterPorId(int id)
        {
            return _context.Tarefas.Where(x => x.Id == id).FirstOrDefault();
        }


        public List<Tarefa> ObterTodos()
        {
            return _context.Tarefas.ToList();
        }


        public Tarefa ObterPorTitulo(string titulo)
        {
            return _context.Tarefas.Where(x => x.Titulo == titulo).FirstOrDefault();
        }
        public Tarefa ObterPorData(DateTime data)
        {
            return _context.Tarefas.Where(x => x.Data.Date == data.Date).FirstOrDefault();
        }

        public Tarefa ObterPorStatus(EnumStatusTarefa status)
        {
            return _context.Tarefas.Where(x => x.Status == status).FirstOrDefault();
        }

        public void Criar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Atualizar(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var tarefa = _context.Tarefas.Where(x => x.Id == id).FirstOrDefault();
            _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();

        }
    }

}
