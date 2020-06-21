using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s16985_kol_apbd.DTOs.Request;
using s16985_kol_apbd.DTOs.Response;
using s16985_kol_apbd.Models;

namespace s16985_kol_apbd.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly MyDbContext _context;

        public MyController(MyDbContext context)
        {
            _context = context;
                 
        }

        [HttpGet("{id}")]
         public IActionResult GetMusician(int id)
        {
            Musician musician;
            ICollection<Track> tracks = new List<Track>();
            ICollection<int> idtracks;
            try {
                musician = _context.Musicians.Where(e => e.IdMusician == id).Single();

            }
            catch (Exception exc)
            {
                return NotFound("BRak podanego artysty");
            }
            try
            {
                idtracks = _context.Musician_Tracks.Where(e => e.IdMusician == id).Select(e => e.IdTrack).ToList();
                foreach (int idTrack in idtracks)
                {
                    var tempTrack = _context.Tracks.Where(e => e.IdTrack == idTrack).First();
                    tracks.Add(tempTrack);
                }

                var response = new MusicianResponse
                {
                    FirstName = musician.FirstName,
                    LastName = musician.LastName,
                    Nickname = musician.Nickname,
                    MusicianTracks = tracks
                };

                return Ok(response);
            }
            catch (ArgumentNullException exc)
            {

                return NotFound("BRak utworów dla podanego artysty");
            }
        }

        [HttpPost]
        public IActionResult CreateMusiacian(CreateMusicianDTORequest request)
        {
            Track track;

            if(!_context.Tracks.Any(t => t.TrackName == request.TrackDTO.TrackName))
            {
                track = new Track
                {
                    TrackName = request.TrackDTO.TrackName,
                    Duration = request.TrackDTO.duration
                };
            }
            else
            {
                track = _context.Tracks.Where(t => t.TrackName == request.TrackDTO.TrackName && t.Duration == request.TrackDTO.duration).First();
            }

            var musician = new Musician
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Nickname = request.NickName
            };

            var musicianTrack = new Musician_Track
            {
                Musician = musician,
                Track = track
            };

            return Created(Uri.EscapeDataString(""), musician);
        }
    }
}