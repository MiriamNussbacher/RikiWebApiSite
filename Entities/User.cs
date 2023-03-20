using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
