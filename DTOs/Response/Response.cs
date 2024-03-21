using System.Text.Json.Serialization;

namespace WebApi.DTO.Response
{
    public class Response<T>
    {
        public T? Dados { get; private set; }
        public string Mensagem { get; private set; } = string.Empty;
        public bool Sucesso { get; private set; } = true;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Token { get; private set; }

        public void SetData(T dados) =>        
            Dados = dados;
        

        public void SetMessage(string Message) =>        
            Mensagem = Message;
        

        public void SetSuccess(bool success) =>      
            Sucesso = success;


        public void SetToken(string tok) =>
            Token = tok;


        public Response() { }
    }
}