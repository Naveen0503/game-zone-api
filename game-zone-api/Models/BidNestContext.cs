using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace game_zone_api.Models;

public partial class BidNestContext : DbContext
{
    public BidNestContext()
    {
    }

    public BidNestContext(DbContextOptions<BidNestContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Gamer> Gamers { get; set; }
    public virtual DbSet<Score> Scores { get; set; }
}
