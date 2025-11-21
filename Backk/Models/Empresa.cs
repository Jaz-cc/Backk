using System;
using System.Collections.Generic;

namespace Backk.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Direccion { get; set; }
    public string? Sector { get; set; }
    public string? SitioWeb { get; set; }    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
    public virtual ICollection<Vacante> Vacantes { get; set; } = new List<Vacante>();
}
