using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Data;
using webAPI.Data.Entities;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly ApiContext context;
        public MusicsController(ApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Music>> Get() 
        {
            return context.Music.ToList();
        }

        [HttpGet("{id}" , Name = "ObtenerMusicaPorId")]
        public ActionResult<Music> Get (int id) 
        {
            var music = context.Music.FirstOrDefault(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            return music;
        }

        [HttpPost]
        public ActionResult<Music> Post([FromBody] Music music) 
        {
            context.Music.Add(music);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerMusicaPorId", new { id = music.Id }, music);
        }

        [HttpPut("{id}")]
        public ActionResult<Music> Put(int id, [FromBody] Music music)
        {
            if (id != music.Id)
            {
                return BadRequest();
            }
            context.Entry(music).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Music> Delete(int id) 
        {
            var music = context.Music.FirstOrDefault(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }
            context.Music.Remove(music);
            context.SaveChanges();
            return Ok();
        }
    }
}
