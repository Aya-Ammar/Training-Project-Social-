using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social1.Models;

public partial class AppUser
{

    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Age { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Commant> Commants { get; set; } = new List<Commant>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
