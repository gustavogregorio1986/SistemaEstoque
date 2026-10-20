using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.DTO;

namespace SistemaEstoque.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            var user = new IdentityUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email
            };

            // 1. Usando await corretamente em vez de .Result
            var result = await _userManager.CreateAsync(user, registerDto.Senha);

            if (result.Succeeded)
            {
                // 2. Verifica se a role existe; se não existir, cria (ou garanta que ela já exista no banco)
                if (!await _roleManager.RoleExistsAsync(registerDto.Perfil))
                {
                    await _roleManager.CreateAsync(new IdentityRole(registerDto.Perfil));
                }

                // 3. Adiciona o usuário na role escolhida
                await _userManager.AddToRoleAsync(user, registerDto.Perfil);

                TempData["MensagemSucesso"] = $"Usuário {user.UserName} registrado com sucesso!";
                return RedirectToAction("Register", "Account"); // Defina a rota de destino
            }

            // Se falhar na criação (ex: senha fraca, email já cadastrado), adiciona os erros ao ModelState
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerDto);
        }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto loginDto)
        {
            if(!ModelState.IsValid) return View(loginDto);

            var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Senha, true, false);

            if (result.Succeeded)
            {
                TempData["MensagemSucesso"] = $"Usuário {loginDto.Email} logado com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            TempData["MensagemErro"] = $"Ocorreu um erro no processo.";
            return View(loginDto);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
