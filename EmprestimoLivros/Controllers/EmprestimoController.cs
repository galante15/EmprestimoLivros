using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _db;

        public EmprestimoController(ApplicationDbContext db) { 
        
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos; //aqui fomos no banco de dados e pegamos todos os registros
            return View(emprestimos); // Nessa linha,  ele vai até o view/emprestimo/index e entra na verificação e dps no foreach
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet] // aqui pega as informações do banco/tela.
        public IActionResult Editar(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            // acima nos entramos no emprestimomodel( que é aonde declaramos cada campo do banco de dados)
            // após o sinal de igual fomos no banco de dados e pegamos o primeiro registro(FirstOrDefault)
            // e o x é a mesma coisa que um where(where id = id). Basicamente ta fazendo uma comparação
            //resumindo, a expressão toda é um select no banco
            if (emprestimo == null) 
            {
                return NotFound();
            }
            
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost] // aqui salva as informações no banco/tela
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if(ModelState.IsValid)
            { 
                _db.Emprestimos.Add(emprestimos); //_db entrando no banco de dados ... Emprestimos entrando na tabela ... add to adicionando 
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Castro Realizado com Sucesso";

                return RedirectToAction("Index");
            }
                

            return View();
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição Realizado com Sucesso";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Edição não realizada";


            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if(emprestimo == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção Realizado com Sucesso";

            return RedirectToAction("index");
        }
    }
}
