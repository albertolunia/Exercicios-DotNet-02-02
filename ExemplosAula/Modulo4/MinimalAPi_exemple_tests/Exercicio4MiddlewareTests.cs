using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Modulo4.Exercicios;

public class Exercicio4MiddlewareTests
{
    [Fact]
    public async Task Middleware_Catches_Exception()
    {
        // Arrange
        var middleware = new Exercicio4Middleware((innerHttpContext) =>
        {
            throw new Exception("Test exception");
        });

        var context = new DefaultHttpContext();
        context.Response.Body = new MemoryStream();

        // Act
        await middleware.Invoke(context);

        // Assert
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(context.Response.Body);
        var text = reader.ReadToEnd();

        Assert.Contains("Test exception", text);
    }
}
