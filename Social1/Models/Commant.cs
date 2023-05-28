using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social1.Models;

public partial class Commant
{

   
    public long Id { get; set; }

    public string Body { get; set; } = null!;

    public DateTime Data { get; set; }

    public long Appuserid { get; set; }

    public long? Postid { get; set; }

    public virtual AppUser Appuser { get; set; } = null!;

    public virtual Post? Post { get; set; }
}
