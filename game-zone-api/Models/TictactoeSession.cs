using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace game_zone_api.Models;

public partial class TictactoeSession
{
    [Key]
    public int SessionId { get; set; }

    public int Player1Id { get; set; }

    public int Player2Id { get; set; }

    public int CurrentPlayerId { get; set; }

    public string GameBoard { get; set; } = null!;

    public string GameStatus { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
