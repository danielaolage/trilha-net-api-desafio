using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Services;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;
        private readonly TarefaService _tarefaService;

        public TarefaController(OrganizadorContext context, TarefaService tarefaService)
        {
            _context = context;
            _tarefaService = tarefaService;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var x = _tarefaService.ObterPorId(id);
            if (x != null)
                return Ok(x);
            else
                return NotFound();
        }

        [HttpGet("ObterTodos")]
        public ActionResult<List<Tarefa>> ObterTodos()
        {
            return Ok(_tarefaService.ObterTodos());
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var x = _tarefaService.ObterPorTitulo(titulo);
            if (x != null)
                return Ok(x);
            else
                return NotFound();
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var x = _tarefaService.ObterPorData(data);
            if (x != null)
                return Ok(x);
            else
                return NotFound();
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var x = _tarefaService.ObterPorStatus(status);
            if (x != null)
                return Ok(x);
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _tarefaService.Criar(tarefa);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            _tarefaService.Atualizar(tarefa);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            _tarefaService.Deletar(id);

            return NoContent();
        }
    }
}
