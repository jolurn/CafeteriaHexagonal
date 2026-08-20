using AplicacionCafeteria.Interfaces;
using AplicacionCafeteria.Servicios;
using DominioCafe.Interfaces;
using Microsoft.EntityFrameworkCore;
using RepositorioCafe;
using RepositorioCafe.Contexto;

var builder = WebApplication.CreateBuilder(args);
// ============================================
// 1. CONFIGURACIÓN DE SERVICIOS
// ============================================

// 🔗 CONEXIÓN A BASE DE DATOS
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextoCafeteria>(options =>
    options.UseSqlServer(connectionString));

// 📦 REGISTRO DE DEPENDENCIAS (Inyección de dependencias)
builder.Services.AddTransient<IRepositorioCafe, CafeRepositorio>();
builder.Services.AddTransient<IObtenerCafe, CafeRepositorio>();
builder.Services.AddTransient<IPrepararCafe, CafeRepositorio>();
builder.Services.AddTransient<IServicioCafe, ServicioCafe>();
builder.Services.AddTransient<IServicioPrepararCafe, ServicioPrepararCafe>();

// ⚙️ SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ============================================
// 2. MIDDLEWARE
// ============================================

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ============================================
// 3. ENDPOINTS (Adaptador de Entrada)
// ============================================

/// GET /cafes - Obtener todos los cafés


app.MapGet("/cafes", async (IServicioCafe servicio) =>
{
    var cafes = await servicio.ObtenerTodosAsync();
    return Results.Ok(cafes);
}).WithName("ObtenerCafes")
  .WithOpenApi();

/// GET /cafes/{id} - Obtener café por ID
app.MapGet("/cafes/{id}", async (int id, IServicioCafe servicio) =>
{
    var cafe = await servicio.ObtenerPorIdAsync(id);
    if (cafe == null)
        return Results.NotFound($"No se encontró el café con ID {id}");
    return Results.Ok(cafe);
}).WithName("ObtenerCafePorId")
  .WithOpenApi();

/// POST /cafes - Crear un nuevo café
app.MapPost("/cafes", async (AplicacionCafeteria.DTOs.CafeDTO cafeDTO, IServicioCafe servicio) =>
{
    var cafeCreado = await servicio.CrearAsync(cafeDTO);
    return Results.Created($"/cafes/{cafeCreado.Id}", cafeCreado);
}).WithName("CrearCafe")
  .WithOpenApi();

/// PUT /cafes - Actualizar un café
app.MapPut("/cafes", async (AplicacionCafeteria.DTOs.CafeDTO cafeDTO, IServicioCafe servicio) =>
{
    try
    {
        var cafeActualizado = await servicio.ActualizarAsync(cafeDTO);
        return Results.Ok(cafeActualizado);
    }
    catch (InvalidOperationException ex)
    {
        return Results.NotFound(ex.Message);
    }
}).WithName("ActualizarCafe")
  .WithOpenApi();

/// PUT /cafes/preparar/{id} - Preparar un café
app.MapPut("/cafes/preparar/{id}", async (int id, IServicioPrepararCafe servicio) =>
{
    try
    {
        await servicio.PrepararAsync(id);
        return Results.NoContent();
    }
    catch (InvalidOperationException ex)
    {
        return Results.NotFound(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(
            title: "Error interno del servidor",
            detail: ex.Message,
            statusCode: 500
        );
    }
}).WithName("PrepararCafe")
  .WithOpenApi();

app.Run();

