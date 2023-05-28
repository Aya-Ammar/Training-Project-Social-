using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social1.Models;

public partial class Post
{

   
    public long Id { get; set; }

    public string Body { get; set; } = null!;

    public string Title { get; set; } = null!;

    public long? Appuserid { get; set; }

    public virtual AppUser? Appuser { get; set; }

    public virtual ICollection<Commant> Commants { get; set; } = new List<Commant>();
}
