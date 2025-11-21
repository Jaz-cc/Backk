using System;
using System.Collections.Generic;

namespace Backk.Models;

public partial class Contacto
{
    public int IdContacto { get; set; }
    public int IdEmpresa { get; set; }
    public string NombreContacto { get; set; } = null!;
    public string? Telefono { get; set; }
    public string? Correo { get; set; }
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
