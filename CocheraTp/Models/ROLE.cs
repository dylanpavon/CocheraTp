﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CocheraTp.Models;

public partial class ROLE
{
    public int id_roles { get; set; }

    public string descripcion { get; set; }

    public virtual ICollection<USUARIO> USUARIOs { get; set; } = new List<USUARIO>();
}