namespace DesafioFIAP.Responses
{
    public class Response<T> : IResponse<T>
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public T? Dados { get; set; }

        public static Response<T> Ok(T dados, string? mensagem = null) =>
            new() { Sucesso = true, Dados = dados, Mensagem = mensagem };

        public static Response<T> Falha(string mensagem) =>
            new() { Sucesso = false, Mensagem = mensagem };
    }
}
