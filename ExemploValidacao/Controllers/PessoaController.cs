using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using ExemploValidacao.Models;

namespace ExemploValidacao.Controllers
{
    public class PessoaController : Controller
    {
        //
        // GET: /Pessoa/
        public ActionResult Index()
        {
            return View(new Pessoa());
        }

        //recebo uma pessoa
        [HttpPost]
        public ActionResult Index(Pessoa pessoa)
        {
            // erro na propriedade
            //if(String.IsNullOrEmpty(pessoa.Nome))
            //  ModelState.AddModelError("Nome", "O campo nome não deve estar vazio.");

            //erro no validation sumary
            //if (pessoa.Senha != pessoa.ConfirmarSenha)
            //ModelState.AddModelError("","As senha não conferem");


            if (ModelState.IsValid)
            {
                return View("Resultado", pessoa);
            }
            return View();
        }

        public ActionResult Resultado(Pessoa pessoa)
        {
            return View(pessoa);
        }

        public ActionResult LoginUnico(string login)
        {
            var banco = new Collection<string>
            {
                "Cleyton",
                "Anderson",
                "Fernanda",
                "Alex",
                "Marciel"
            };
            return Json(banco.All(x => x.ToLower() != login.ToLower()), JsonRequestBehavior.AllowGet);
        }
    }
}