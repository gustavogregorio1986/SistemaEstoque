namespace SistemaEstoque.Models
{
    public class ResponseModel<T>
    {
        public string Mensagem { get; set; }

        public bool Status { get; set; } = true;

        public T? Dados { get; set; }
    }
}
