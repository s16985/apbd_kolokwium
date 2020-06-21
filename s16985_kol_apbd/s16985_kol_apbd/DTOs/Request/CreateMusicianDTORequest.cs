using s16985_kol_apbd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s16985_kol_apbd.DTOs.Request
{
	public class CreateMusicianDTORequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		public CreateTrackDtoRequest TrackDTO { get; set; }
	}

	public class CreateTrackDtoRequest
	{
		public string TrackName { get; set; }
		public float duration { get; set; }
	}
}
