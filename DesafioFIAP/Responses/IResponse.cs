namespace DesafioFIAP.Responses
{
    public interface IResponse<T>
    {
        bool Sucesso { get; }
        string? Mensagem { get; }
        T? Dados { get; }
    }
}
