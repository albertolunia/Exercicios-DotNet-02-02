using System.Diagnostics;

namespace Modulo4.Exercicios;

//Implementar um middleware que regitra o tempo de duração de cada requisição em milisegundos
public class Exercicio3Middleware
{
    private readonly RequestDelegate _next;
    public Exercicio3Middleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        await _next(context);
        stopwatch.Stop();
        var ticks = stopwatch.ElapsedTicks;
        await context.Response.WriteAsync($"Exercicio 3:");
        await context.Response.WriteAsync($"</br>Tempo_Requisicao_MileSegundos {stopwatch.ElapsedMilliseconds.ToString()}");
        await context.Response.WriteAsync($"</br>Tempo_Requisicao_MicroSegundos {ticks/1000}");
        //context.Response.Headers.Add("Tempo_Requisicao", (stopwatch.Elapsed.TotalMilliseconds * 1000).ToString());
    }
}
