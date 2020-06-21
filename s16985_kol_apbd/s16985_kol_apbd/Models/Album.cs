using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace s16985_kol_apbd.Models
{
	public class Album
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdAlbum { get; set; }
		[MaxLength(30)]
		[Required]
		public string AlbumName { get; set; }
		public DateTime PublishDate { get; set; }

		public int IdMusicLabel { get; set; }

		public int? IdMusicAlbum { get; set; }

		[ForeignKey("IdMusicLabel")]
		public MusicLabel MusicLabel { get; set; }

		public ICollection<Track> Tracks { get; set; }
	}
}
