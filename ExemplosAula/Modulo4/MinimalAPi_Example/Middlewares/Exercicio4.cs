using System.Text.Json;

namespace Modulo4.Exercicios;

//Implemente um middleware customizado que intercepte todas as exceções e gere um json e envie para uma endpoint especifico
public class Exercicio4Middleware
{
    private readonly RequestDelegate _next;
    public Exercicio4Middleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = ex.Message }));
        }
    }
}
