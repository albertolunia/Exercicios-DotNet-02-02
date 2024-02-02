using Middleware.Extensions;
using Modulo4.LinhaDeMontagem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LinhaDeMontagemDescricao>();

var app = builder.Build();
//app.UseHttpsRedirection();

//app.UseExercicio2Middleware();
app.UseExercicio3Middleware();
app.UseExercicio1Middleware();
app.UseExercicio4Middleware();
app.UseAddChassiMiddleware();
// app.UseAddMotorMiddleware();
// app.UseMiddleware<AddPortasMiddleware>();
// app.UseMiddleware<AddPinturaMiddleware>();
// app.UseMiddleware<AddInternoMiddleware>();


app.Run();
