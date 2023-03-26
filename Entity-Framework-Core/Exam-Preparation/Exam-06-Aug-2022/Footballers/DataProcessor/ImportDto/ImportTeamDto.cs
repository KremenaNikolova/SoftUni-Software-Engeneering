using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footballers.DataProcessor.ImportDto
{
    public class ImportTeamDto
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [RegularExpression(@"[a-zA-z.\-\d\s]+$")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Nationality { get; set; } = null!;

        [Required]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
