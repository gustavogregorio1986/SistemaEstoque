using System.ComponentModel.DataAnnotations;

namespace SistemaEstoque.DTO
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O campo Confirmar Senha é obrigatório")]
        [Compare("ConfirmarSenha", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmarSenha { get; set; }
        [Required(ErrorMessage = "Selecione Perfil é obrigatório")]
        public string Perfil { get; set; }
    }
}
