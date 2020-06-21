using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s16985_kol_apbd.Models
{
	public class Musician
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdMusician { get; set; }
		[MaxLength(30)]
		[Required]
		public string FirstName { get; set; }
		[MaxLength(50)]
		[Required]
		public string LastName { get; set; }
		[MaxLength(20)]
		public string? Nickname { get; set; }

		public ICollection<Musician_Track> MusicianTracks { get; set; }
	}
}
