namespace Api;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Contraseña { get; set; }
    public List<Rol> Roles { get; set; } = new List<Rol>();
}