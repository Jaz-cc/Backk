using System;
using System.Collections.Generic;

namespace Backk.Models;

public partial class Vacante
{
    public int IdVacante { get; set; }
    public int IdEmpresa { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }
    public decimal? Salario { get; set; }
    public DateOnly? FechaPublicacion { get; set; }
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
    public virtual ICollection<Requisito> Requisitos { get; set; } = new List<Requisito>();
}
