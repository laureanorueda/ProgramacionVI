namespace ActividadWebApi.Models;

public class Dispositivo
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Ip { get; set; } = string.Empty;
    public bool Activo { get; set; }
}