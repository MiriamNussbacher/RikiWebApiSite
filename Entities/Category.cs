﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
