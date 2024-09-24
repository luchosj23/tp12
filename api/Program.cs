using Api;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

List<Usuario> usuarios = [
    new Usuario {Id = 2, Nombre = "Juan" , Correo = "juan@gmail.com", usuario = "juann", Contraseña ="1223"},
    new Usuario {Id = 3, Nombre = "Axel",  Correo = "axel@gmail.com", usuario = "axell", Contraseña ="12"}
];

List<Rol> roles = [
    new Rol{ Id=1, Nombre="Estudiante"},
    new Rol{ Id=2, Nombre="Profesor"}
    ];

//Usuario
app.MapPost("/usuario", ([FromBody] Usuario usuario) =>
{

    if (string.IsNullOrWhiteSpace(usuario.Nombre))
    {
        return Results.BadRequest("El nombre del usuario no puede ser vacío o nulo.");
    }
    usuarios.Add(usuario);
    return Results.Created($"/usuario/{usuario.Id}", usuario);
})
    .WithTags("usuario");

app.Run();