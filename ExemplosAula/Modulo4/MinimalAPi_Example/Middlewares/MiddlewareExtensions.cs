using Modulo4.LinhaDeMontagem;
using Modulo4.Exercicios;

namespace Middleware.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseAddChassiMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AddChassiMiddleware>();
        }

        public static IApplicationBuilder UseAddMotorMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AddMotorMiddleware>();
        }

        public static IApplicationBuilder UseExercicio1Middleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Exercicio1Middleware>();
        }

        public static IApplicationBuilder UseExercicio2Middleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Exercicio2Middleware>();
        }

        public static IApplicationBuilder UseExercicio3Middleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Exercicio3Middleware>();
        }
    }
}
