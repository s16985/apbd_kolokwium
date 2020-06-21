using s16985_kol_apbd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16985_kol_apbd.DTOs.Response
{
	public class MusicianResponse
	{
		public string FirstName { get; set; }
		
		public string LastName { get; set; }
		
		public string? Nickname { get; set; }

		public ICollection<Track> MusicianTracks { get; set; }
	}
}
