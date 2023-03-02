﻿namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Color
{
   

    public int ColorId { get; set; }

    [Required]
    [MaxLength(15)]
    public string Name { get; set; } = null!;

    [InverseProperty(nameof(Team.PrimaryKitColor))]
    public ICollection<Team>? PrimaryKitTeams { get; set; }

    [InverseProperty(nameof(Team.SecondaryKitColor))]
    public ICollection<Team>? SecondaryKitTeams { get; set; }
}