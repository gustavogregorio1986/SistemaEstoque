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
                    TempData["MensagmeErro"] = response.Mensgame;
                }

                TempData["MensagemSucesso"] = response.Mensgame;

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
    }
}
