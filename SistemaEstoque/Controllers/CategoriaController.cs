using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.DTO;
using SistemaEstoque.Services.Categorias;

namespace SistemaEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaInterface _categoriaInterface;


        public CategoriaController(ICategoriaInterface categoriaInterface)
        {
            _categoriaInterface = categoriaInterface;   
        }
        public async  Task<IActionResult> Index()
        {
            var categorias = await _categoriaInterface.ObterTodosAsync();

            return View(categorias);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaDto categoriaDto)
        {
           if(ModelState.IsValid)
           {
                var response = await _categoriaInterface.AdicionarAsync(categoriaDto);

                if (!response.Status)
                {
                    TempData["MensagmeErro"] = response.Mensagem;
                }

                TempData["MensagemSucesso"] = response.Mensagem;

                return RedirectToAction("Index");
           }

           return View(categoriaDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaInterface.ObterPorIdAsync(id);
            if (categoria == null)
            {
                TempData["MensagemErro"] = "Categoria não encontrada!";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _categoriaInterface.RemoverAsync(id);

            if (!response.Status)
            {
                TempData["MensagemErro"] = response.Mensagem;
                return RedirectToAction("Index", new { id = id }); // ou Index, dependendo de para onde o vídeo manda
            }

            TempData["MensagemSucesso"] = response.Mensagem; // Caso tenha mensagem de sucesso
            return RedirectToAction("Index");
        }
    }
}
