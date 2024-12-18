﻿namespace Footballers.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Team
    {
        public Team()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [Required]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public ICollection<TeamFootballer> TeamsFootballers { get; set; }
    }
}
