﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CocheraTp.Models;

public partial class REMITO
{
    public int id_remito { get; set; }

    public int? id_vehiculo { get; set; }

    public string id_lugar { get; set; }

    public DateTime? fecha_entrada { get; set; }
}