using Microsoft.AspNetCore.Mvc;
using GlobalBankApi.Data;
using GlobalBankApi.Models;

namespace GlobalBankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Registrar(Transacao transacao)
        {
            var conta = _context.Contas.Find(transacao.ContaId);
            if (conta == null) return NotFound();

            if (transacao.Tipo == "Saque" && transacao.Valor > conta.Saldo)
                return Conflict("Saldo insuficiente");

            if (transacao.Tipo == "Deposito")
                conta.Saldo += transacao.Valor;
            else if (transacao.Tipo == "Saque")
                conta.Saldo -= transacao.Valor;

            if (transacao.Valor > 10000)
            {
                Console.WriteLine($"🚩 ALERTA: Transação alta na conta {conta.NumeroConta}");
            }

            transacao.DataTransacao = DateTime.Now;

            _context.Transacoes.Add(transacao);
            _context.SaveChanges();

            return Ok(transacao);
        }

        [HttpGet("extrato/{contaId}")]
        public ActionResult Extrato(int contaId)
        {
            return Ok(_context.Transacoes.Where(t => t.ContaId == contaId).ToList());
        }
    }
}