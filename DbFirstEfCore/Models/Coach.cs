using System;
using System.Collections.Generic;

namespace DbFirstEfCore.Models;

public partial class Coach
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string DateCreated { get; set; } = null!;
}
