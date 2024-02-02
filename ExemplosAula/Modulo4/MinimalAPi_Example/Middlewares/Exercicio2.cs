using System.Diagnostics;

namespace Modulo4.Exercicios;

//Implementar um middleware que regitra o tempo de duração de cada requisição em milisegundos
public class Exercicio2Middleware
{
    private readonly RequestDelegate _next;
    public Exercicio2Middleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _next(context);
        stopwatch.Stop();
        await context.Response.WriteAsync($"Tempo_Requisicao {stopwatch.ElapsedMilliseconds.ToString()}");
        //context.Response.Headers.Add("Tempo_Requisicao", stopwatch.ElapsedMilliseconds.ToString());
    }
}
