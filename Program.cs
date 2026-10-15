using LH_Pets.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

// Coleções em memória para a etapa de prototipagem. Os dados são reiniciados ao parar a API.
public static class BancoEmMemoria
{
    public static List<Cliente> Clientes { get; } = new();
    public static List<Pet> Pets { get; } = new();
    public static int ProximoClienteId => Clientes.Count == 0 ? 1 : Clientes.Max(c => c.Id) + 1;
    public static int ProximoPetId => Pets.Count == 0 ? 1 : Pets.Max(p => p.Id) + 1;
}
