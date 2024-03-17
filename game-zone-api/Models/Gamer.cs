using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace game_zone_api.Models;

public partial class Gamer
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
}
