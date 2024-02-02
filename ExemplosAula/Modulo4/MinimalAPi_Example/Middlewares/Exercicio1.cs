namespace Modulo4.Exercicios;

//Crie um middleware que adicione um cabeçalho personalizado a todas as respostas do servidor, trazendo a hora e o ip de cada solicitação feita para o servidor

public class Exercicio1Middleware
{
    private readonly RequestDelegate _next;
    public Exercicio1Middleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        context.Response.Headers.Add("Hora_Inicio", DateTime.Now.ToString());
        context.Response.Headers.Add("IP_Inicio", context.Connection.RemoteIpAddress.ToString());
        await _next(context);
        // context.Response.Headers.Add("Hora_Final", DateTime.Now.ToString());
        // context.Response.Headers.Add("IP_Final", context.Connection.RemoteIpAddress.ToString());
    }
}
