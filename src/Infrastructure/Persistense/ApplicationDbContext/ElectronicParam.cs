﻿using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infrastructure.Persistense.ApplicationDbContext;

public partial class ElectronicParam
{
    public int Id { get; set; }

    public string File { get; set; } = null!;
}
