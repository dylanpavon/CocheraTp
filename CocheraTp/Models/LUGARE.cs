﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CocheraTp.Models;

public partial class LUGARE
{
    public string id_lugar { get; set; }

    public bool? seccion_uno { get; set; }

    public bool? seccion_dos { get; set; }

    public virtual ICollection<DETALLE_FACTURA> DETALLE_FACTURAs { get; set; } = new List<DETALLE_FACTURA>();

    public virtual ICollection<REMITO> REMITOs { get; set; } = new List<REMITO>();
}