using GrpcService.Core.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

WebApplication app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Service is up and running...");

app.Run();
