using System;
using System.Collections.Generic;

namespace Backk.Models;

public partial class Requisito
{
    public int IdRequisito { get; set; }
    public int IdVacante { get; set; }
    public string Descripcion { get; set; } = null!;
    public virtual Vacante IdVacanteNavigation { get; set; } = null!;
}
