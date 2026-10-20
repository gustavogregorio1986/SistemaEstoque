namespace SistemaEstoque.Models
{
    public class ResponseModel<T>
    {
        public string Mensgame { get; set; }

        public bool Status { get; set; }

        public T? Dados { get; set; }
    }
}
