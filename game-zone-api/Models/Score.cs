using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace game_zone_api.Models;

public partial class Score
{
    [Key]
    public int Id { get; set; }

    public int? GamerId { get; set; }

    public string Game { get; set; } = null!;

    public int? Score1 { get; set; }

    public virtual Gamer? Gamer { get; set; }
}
