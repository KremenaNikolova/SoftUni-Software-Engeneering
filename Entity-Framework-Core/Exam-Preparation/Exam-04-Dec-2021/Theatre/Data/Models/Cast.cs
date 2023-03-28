﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FullName { get; set; } = null!;

        public bool IsMainCharacter { get; set; }

        [Required]
        public string PhoneNumber { get; set; } = null!; //regex

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        [Required]
        public virtual Play Play { get; set; } = null!;
    }
}
