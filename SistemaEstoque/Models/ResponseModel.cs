namespace SistemaEstoque.Models
{
    public class ResponseModel<T>
    {
        public string Mensgame { get; set; }

        public bool Status { get; set; } = true;

        public T? Dados { get; set; }
    }
}
