﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CocheraTp.Models;

public partial class ABONO
{
    public int id_abono { get; set; }

    public string descripcion { get; set; }

    public decimal? precio { get; set; }

    public virtual ICollection<DETALLE_FACTURA> DETALLE_FACTURAs { get; set; } = new List<DETALLE_FACTURA>();
}