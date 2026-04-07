using Microsoft.AspNetCore.Mvc;
using GlobalBankApi.Data;
using GlobalBankApi.Models;

namespace GlobalBankApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult CriarConta(ContaBancaria conta)
        {
            if (conta.Saldo < 0)
                return BadRequest("O saldo inicial não pode ser negativo para contas internacionais.");

            _context.Contas.Add(conta);
            _context.SaveChanges();

            return Ok(conta);
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.Contas.ToList());
        }

        // 👇 COLOCA AQUI EMBAIXO
        [HttpGet("/api/banco/dashboard")]
        public ActionResult Dashboard()
        {
            var total = _context.Contas.Sum(c => c.Saldo);
            var transacoes = _context.Transacoes.Count();

            return Ok(new
            {
                patrimonioTotal = total,
                totalTransacoes = transacoes
            });
        }
    }
}