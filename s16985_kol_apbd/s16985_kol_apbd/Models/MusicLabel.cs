using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s16985_kol_apbd.Models
{
	public class MusicLabel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdMusicLabel { get; set; }
		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		public ICollection<Album> Albums { get; set; }
	}
}
