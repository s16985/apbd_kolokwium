using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s16985_kol_apbd.Models
{
	public class Track
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdTrack { get; set; }
		[MaxLength(20)]
		[Required]
		public string TrackName { get; set; }
		[Required]
		public float Duration { get; set; }
		public int? IdMusicAlbum { get; set; }

		[ForeignKey("IdMusicAlbum")]
		public virtual Album album { get; set; }

		public ICollection<Musician_Track> MusicianTracks { get; set; }


	}
}
